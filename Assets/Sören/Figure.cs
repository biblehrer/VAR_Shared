using UnityEngine;

public class Figure : MonoBehaviour
{
    public Marker marker;

    public void ResetTransform()
    {
        GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        transform.position = marker.startPos;
    }
}