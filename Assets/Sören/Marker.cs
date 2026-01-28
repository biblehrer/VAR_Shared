using UnityEngine;

public class Marker : MonoBehaviour
{
    public GameObject fig;
    public Vector3 startPos;

    private void Start()
    {
        startPos = fig.transform.position;
        fig.GetComponent<Figure>().marker = this;
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}