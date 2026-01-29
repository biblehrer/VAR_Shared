using UnityEngine;

public class HeadAngleReveal : MonoBehaviour
{
    [Header("Camera (XR HMD)")]
    public Transform headCamera;

    [Header("Reveal by head pitch (looking down)")]
    [Tooltip("Нужный наклон головы вниз. Пример: 45.")]
    public float targetPitch = 45f;

    [Tooltip("Допуск в градусах. Пример: 10 -> работает от 35 до 55.")]
    public float tolerance = 10f;

    [Header("Optional: also require player to be near")]
    public bool requireDistance = true;
    public float maxDistance = 1.5f;

    [Header("Renderers to toggle (if empty -> will auto-find)")]
    public Renderer[] renderers;

    private bool isVisible = false;

    private void Start()
    {
        if (headCamera == null && Camera.main != null)
            headCamera = Camera.main.transform;

        if (renderers == null || renderers.Length == 0)
            renderers = GetComponentsInChildren<Renderer>(true);

        SetVisible(false);
    }

    private void Update()
    {
        if (headCamera == null) return;

        float pitch = NormalizeAngle(headCamera.eulerAngles.x);
        float diff = Mathf.Abs(pitch - targetPitch);

        bool angleOk = diff <= tolerance;

        bool distanceOk = true;
        if (requireDistance)
        {
            float d = Vector3.Distance(headCamera.position, transform.position);
            distanceOk = d <= maxDistance;
        }

        bool shouldBeVisible = angleOk && distanceOk;

        if (shouldBeVisible != isVisible)
            SetVisible(shouldBeVisible);
    }

    private void SetVisible(bool on)
    {
        isVisible = on;
        foreach (var r in renderers)
            if (r != null) r.enabled = on;
    }

    private float NormalizeAngle(float angle)
    {
        while (angle > 180f) angle -= 360f;
        while (angle < -180f) angle += 360f;
        return angle;
    }
}
