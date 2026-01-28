using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Unity.XR.CoreUtils;

public class PortalTransition : MonoBehaviour
{
    [Header("Fade UI")]
    public Image fadeImage;
    public float fadeToBlackTime = 0.5f;
    public float blackScreenDuration = 3.0f;
    public float fadeFromBlackTime = 0.7f;

    [Header("Atmosphere switch")]
    public Light[] sceneLights;              // лампы в комнате (все основные)
    public float normalIntensity = 1.2f;
    public float upsideIntensity = 0.3f;

    public Color normalLightColor = new Color(1.0f, 0.92f, 0.8f);   // тёплый
    public Color upsideLightColor = new Color(0.55f, 0.7f, 1.0f);   // холодный

    [Header("Ash particles (enable on switch)")]
    public GameObject ashParticles;

    private bool triggered = false;

    private void Start()
    {
        if (ashParticles != null)
            ashParticles.SetActive(false);

        // на старте делаем fadeImage прозрачным
        if (fadeImage != null)
        {
            var c = fadeImage.color;
            c.a = 0f;
            fadeImage.color = c;
        }
    }

    private void OnTriggerEnter(Collider other)
{
    if (triggered) return;

    // Проверяем: это XR Origin (игрок)?
    var xrOrigin = other.GetComponentInParent<XROrigin>();
    if (xrOrigin == null) return; // НЕ игрок → игнорируем

    triggered = true;
    StartCoroutine(DoTransition());
}


    private IEnumerator DoTransition()
    {
        // 1) Fade to black
        yield return StartCoroutine(Fade(0f, 1f, fadeToBlackTime));

        // 2) Black screen
        yield return new WaitForSeconds(blackScreenDuration);

        // 3) Меняем атмосферу во время черного экрана
        ApplyUpsideDownAtmosphere();

        // 4) Fade back
        yield return StartCoroutine(Fade(1f, 0f, fadeFromBlackTime));
    }

    private IEnumerator Fade(float from, float to, float time)
    {
        if (fadeImage == null) yield break;

        float t = 0f;
        Color c = fadeImage.color;

        while (t < time)
        {
            t += Time.deltaTime;
            float a = Mathf.Lerp(from, to, t / time);
            c.a = a;
            fadeImage.color = c;
            yield return null;
        }

        c.a = to;
        fadeImage.color = c;
    }

    private void ApplyUpsideDownAtmosphere()
    {
        // свет: холоднее и темнее
        if (sceneLights != null)
        {
            foreach (var l in sceneLights)
            {
                if (l == null) continue;
                l.intensity = upsideIntensity;
                l.color = upsideLightColor;
            }
        }

        // включаем пепел
        if (ashParticles != null)
            ashParticles.SetActive(true);
    }
}
