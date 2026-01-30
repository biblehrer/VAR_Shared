using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SocketCheck : MonoBehaviour
{
    public int puz = 0;
    public int posGame = 0;
    public bool rightPos = false;
    public InteractionLayerMask layer;
    public GameObject pos;

    private void OnTriggerEnter(Collider collision)
    {
        GameObject game = collision.gameObject;
        var grabInteractable = game.GetComponent<XRGrabInteractable>();
        if (grabInteractable != null && grabInteractable.interactionLayers == layer)
        {
            if (puz > 0)
            {
                if (rightPos)
                {
                    S_GameManager.Instance.figPos[puz].figPos[posGame] = true;
                    grabInteractable.enabled = false;
                    game.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
                    game.transform.position = pos.transform.position;
                    game.transform.rotation = Quaternion.identity;
                    S_GameManager.Instance.CheckFigPos(puz);
                    Destroy(gameObject);
                }
                else
                {
                    StartCoroutine(Waiter(2, game));
                }
            }
            else
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

    private IEnumerator Waiter(float sec, GameObject game)
    {
        yield return new WaitForSeconds(sec);
        game.GetComponent<Figure>().ResetTransform();
    }
}
