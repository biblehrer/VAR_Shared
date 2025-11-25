using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerAnimation : MonoBehaviour
{
    [SerializeField] private InputActionReference activateAction;

    private void OnEnable()
    {
        if (activateAction != null)
        {
            activateAction.action.Enable();
        }
    }

    private void OnDisable()
    {
        if (activateAction != null)
        {
            activateAction.action.Disable();
        }
    }

    private void Update()
    {
        if (activateAction != null && activateAction.action.WasPressedThisFrame())
        {
            GetComponentInChildren<Transform>().GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
