using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SocketCheck : MonoBehaviour
{
    public int puz = 0;
    public int posGame = 0;
    public InteractionLayerMask layer;
    public GameObject pos;

    private void OnTriggerEnter(Collider collision)
    {
        print(collision.name + " en");
        GameObject game = collision.gameObject;
        var grabInteractable = game.GetComponent<XRGrabInteractable>();
        print(grabInteractable.interactionLayers.value + " Layer");
        print(layer.value + " Mask");
        if (grabInteractable != null && grabInteractable.interactionLayers == layer)
        {
            S_GameManager.Instance.figPos[puz].figPos[posGame] = true;
            grabInteractable.enabled = false;
            game.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            game.transform.position = pos.transform.position;
            game.transform.rotation = Quaternion.identity;
            game.GetComponent<Figure>().marker.DestroyMe();
            S_GameManager.Instance.CheckFigPos(puz);

            Destroy(gameObject);
        }
    }
}
