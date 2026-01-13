using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class SocketController : MonoBehaviour
{
    public GameObject accepObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != accepObject)
        {
            transform.parent.GetComponent<XRSocketInteractor>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != accepObject)
        {
            transform.parent.GetComponent<XRSocketInteractor>().enabled = true;
        }
    }
}