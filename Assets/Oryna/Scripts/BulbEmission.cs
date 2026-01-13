using UnityEngine;

public class BulbEmission : MonoBehaviour
{
    [SerializeField] private Renderer rend;
    [SerializeField] private string emissionColorName = "_EmissionColor";
    [SerializeField] private float emissionIntensity = 2.5f;

    [Header("Glow Color")]
    public Color glowColor = new Color(1f, 0.85f, 0.2f, 1f); // тёплый жёлтый

    private MaterialPropertyBlock mpb;

    private void Awake()
    {
        mpb = new MaterialPropertyBlock();
        if (rend == null) rend = GetComponent<Renderer>();
        if (rend == null) rend = GetComponentInChildren<Renderer>();
        SetOn(false);
    }

    public void SetOn(bool on)
    {
        if (rend == null) return;

        rend.GetPropertyBlock(mpb);
        Color emission = on ? glowColor * emissionIntensity : Color.black;
        mpb.SetColor(emissionColorName, emission);
        rend.SetPropertyBlock(mpb);

        if (on) rend.sharedMaterial.EnableKeyword("_EMISSION");
    }
}
