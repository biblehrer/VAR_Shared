using UnityEngine;

public class CandleIgniteTrigger : MonoBehaviour
{
    [SerializeField] private CandleController candle; 

    private void OnTriggerEnter(Collider other)
    {
        
        var match = other.GetComponentInParent<MatchIgnition>();
        if (match == null) return;       
        if (!match.isLit) return;        
        if (candle == null) return;

        candle.Ignite();
    }
}
