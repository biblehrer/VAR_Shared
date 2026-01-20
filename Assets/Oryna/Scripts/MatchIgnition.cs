using UnityEngine;

public class MatchIgnition : MonoBehaviour
{
    [Header("Flame (child object)")]
    public GameObject flameObject;

    [Header("State")]
    public bool isLit = false;

    [HideInInspector] public Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        SetFlame(false);
    }

    public void Ignite()
    {
        if (isLit) return;
        isLit = true;
        SetFlame(true);
    }

    public void Extinguish()
    {
        if (!isLit) return;
        isLit = false;
        SetFlame(false);
    }

    void SetFlame(bool on)
    {
        if (flameObject != null)
            flameObject.SetActive(on);
    }
}
