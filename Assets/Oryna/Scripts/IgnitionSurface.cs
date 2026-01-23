using UnityEngine;

public class IgnitionSurface : MonoBehaviour
{
    [Header("Settings")]
    public float minRelativeSpeed = 0.3f;   
    public float minDirectionDot = 0.5f;    
    public float cooldown = 0.2f;

    [Header("Debug")]
    public bool debugLogs = true;

    float lastIgniteTime;

    [System.Obsolete]
    private void OnTriggerStay(Collider other)
    {
        // other = TipTrigger (на спичке)
        var match = other.GetComponentInParent<MatchIgnition>();
        if (match == null)
        {
            if (debugLogs) Debug.Log("StrikeZone: something entered, but no MatchIgnition found.");
            return;
        }

        if (match.isLit) return;

        if (Time.time - lastIgniteTime < cooldown) return;

        Rigidbody matchRb = match.rb;
        Rigidbody boxRb = GetComponentInParent<Rigidbody>();

        Vector3 vMatch = matchRb ? matchRb.velocity : Vector3.zero;
        Vector3 vBox = boxRb ? boxRb.velocity : Vector3.zero;

        Vector3 relativeV = vMatch - vBox;
        float speed = relativeV.magnitude;

        // Ось "вдоль тёрки" = локальный X StrikeZone
        Vector3 along = transform.right.normalized;
        float dot = (speed > 0.0001f) ? Mathf.Abs(Vector3.Dot(relativeV.normalized, along)) : 0f;

        if (debugLogs)
            Debug.Log($"StrikeZone: speed={speed:F2}, dot={dot:F2}, minSpeed={minRelativeSpeed}, minDot={minDirectionDot}");

        if (speed >= minRelativeSpeed && dot >= minDirectionDot)
        {
            match.Ignite();
            lastIgniteTime = Time.time;
        }
    }
}
