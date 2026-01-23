using UnityEngine;

public class MatchIgnition : MonoBehaviour
{
    public GameObject flameObject;
    public bool isLit = false;

    [HideInInspector] public Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        SetFlame(false);
    }

    public void Ignite()
    {
        if (isLit) return;
        isLit = true;
        SetFlame(true);
        Debug.Log("MATCH IGNITED!");
    }

    void SetFlame(bool on)
    {
        if (flameObject != null)
            flameObject.SetActive(on);
    }
}
