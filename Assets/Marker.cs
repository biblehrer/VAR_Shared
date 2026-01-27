using UnityEngine;

public class Marker : MonoBehaviour
{
    public GameObject fig;
    public Vector3 startPos;

    private void Start()
    {
        S_GameManager.Instance.MarkerDet += DestroyMe;
        startPos = fig.transform.position;
        fig.GetComponent<Figure>().marker = this;
    }

    private void DestroyMe()
    {
        Destroy(this);
    }
}