using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject wind;
    private Vector3 pos;
    public bool right = false;
    void Start()
    {
        pos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chest"))
        {
            if (right)
            {
                wind.transform.position += new Vector3(0, 1, 0);
            }
            else
            {
                transform.position = pos;
            }
        }
    }
}
