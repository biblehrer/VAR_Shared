using UnityEngine;

public class Marker : MonoBehaviour
{
    public GameObject fig;
    private Vector3 startPos;

    private void Start()
    {
        startPos = fig.transform.position;
    }
}
