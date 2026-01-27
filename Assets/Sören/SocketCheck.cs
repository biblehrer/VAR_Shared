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
        print(collision.name + " en");
        var grabInteractable = collision.gameObject.GetComponent<XRGrabInteractable>();
        print(grabInteractable + " obj");
        print(grabInteractable.interactionLayers.value + " Layer");
        print(layer.value + " Mask");
        if (grabInteractable != null && grabInteractable.interactionLayers == layer)
        {
            S_GameManager.Instance.figPos[puz].figPos[posGame] = true;
            S_GameManager.Instance.CheckFigPos(puz);
            grabInteractable.enabled = false;
            print("hit");
        }
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
