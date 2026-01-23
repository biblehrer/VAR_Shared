using UnityEngine;

public class CandleController : MonoBehaviour
{
    [Header("Assign your flame object (Flame_1 / Flame_2 / Flame_3)")]
    [SerializeField] private GameObject flameObject;

    [Header("State")]
    public bool isLit = false;

    private void Start()
    {
        if (flameObject != null)
            flameObject.SetActive(false); // свеча стартует потушенной
    }

    public void Ignite()
    {
        if (isLit) return;
        isLit = true;

        if (flameObject != null)
            flameObject.SetActive(true);

        Debug.Log($"🕯 Candle ignited: {gameObject.name}");
    }
}
