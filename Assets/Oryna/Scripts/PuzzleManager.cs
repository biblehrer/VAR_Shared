using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [Header("Candles (3 objects with CandleController)")]
    public CandleController candle1;
    public CandleController candle2;
    public CandleController candle3;

    [Header("Portal / Rift object to enable")]
    public GameObject portalObject;

    [Header("Optional: effects when portal appears")]
    public AudioSource portalSound;   // можно не ставить
    public GameObject fogObject;      // можно не ставить
    public bool enableFogOnPortal = false;

    private bool portalOpened = false;

    private void Start()
    {
        if (portalObject != null)
            portalObject.SetActive(false);

        if (fogObject != null && enableFogOnPortal)
            fogObject.SetActive(false);
    }

    private void Update()
    {
        if (portalOpened) return;

        if (candle1 != null && candle2 != null && candle3 != null)
        {
            if (candle1.isLit && candle2.isLit && candle3.isLit)
            {
                OpenPortal();
            }
        }
    }

    private void OpenPortal()
    {
        portalOpened = true;

        if (portalObject != null)
            portalObject.SetActive(true);

        if (enableFogOnPortal && fogObject != null)
            fogObject.SetActive(true);

        if (portalSound != null)
            portalSound.Play();

        Debug.Log(" Portal opened! All candles are lit.");
    }
}
