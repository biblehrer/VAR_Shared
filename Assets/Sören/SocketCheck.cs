using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SocketCheck : MonoBehaviour
{
    public int puz = 0;
    public int posGame = 0;
    public InteractionLayerMask layer;

    private void Start()
    {
        S_GameManager.Instance.DetMe[puz] += DestroyMe;
    }

    private void OnTriggerEnter(Collider collision)
    {
        print(collision.name);
        var grabInteractable = collision.gameObject.GetComponent<XRGrabInteractable>();
        if (grabInteractable != null && grabInteractable.interactionLayers == layer)
        {
            S_GameManager.Instance.figPos[puz].figPos[posGame] = true;
            S_GameManager.Instance.CheckFigPos(puz);
            print("hit");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        print(collision.name);
        var grabInteractable = collision.gameObject.GetComponent<XRGrabInteractable>();
        if (grabInteractable != null && grabInteractable.interactionLayers == layer)
        {
            S_GameManager.Instance.figPos[puz].figPos[posGame] = false;
            print("exe");
        }
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
