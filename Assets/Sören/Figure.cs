using UnityEngine;

public class Figure : MonoBehaviour
{
    [HideInInspector]
    public Marker marker;
    private Vector3 pos;

    private void Start()
    {
        if (marker == null)
            pos = transform.position;
    }

    public void ResetTransform()
    {
        GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        if (marker != null)
            transform.position = marker.startPos;
        else
            transform.position = pos;
    }
}