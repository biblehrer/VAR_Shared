using UnityEngine;

public class ResetObj : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Figure>(out Figure fig))
        {
            fig.ResetTransform();
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
