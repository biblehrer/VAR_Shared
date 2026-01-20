using UnityEngine;

public class IgnitionSurface : MonoBehaviour
{
    [Header("Ignition settings")]
    public float minRelativeSpeed = 1.0f;   // насколько быстро надо чиркнуть
    public float cooldown = 0.2f;           // защита от спама

    float lastIgniteTime;

    [System.Obsolete]
    private void OnTriggerStay(Collider other)
    {
        // Мы ожидаем, что в триггер влетает TipTrigger (на спичке)
        // Берём MatchIgnition у родителя
        var match = other.GetComponentInParent<MatchIgnition>();
        if (match == null) return;
        if (match.isLit) return;

        // защита по времени
        if (Time.time - lastIgniteTime < cooldown) return;

        // скорость "трения" = разница скоростей коробка и спички
        Rigidbody matchRb = match.rb;
        Rigidbody boxRb = GetComponentInParent<Rigidbody>();

        Vector3 vMatch = matchRb != null ? matchRb.velocity : Vector3.zero;
        Vector3 vBox = boxRb != null ? boxRb.velocity : Vector3.zero;

        float relativeSpeed = (vMatch - vBox).magnitude;

        if (relativeSpeed >= minRelativeSpeed)
        {
            match.Ignite();
            lastIgniteTime = Time.time;
        }
    }
}
