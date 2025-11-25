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
            Renderer obj = GetComponentsInChildren<Transform>()[1].GetComponent<Renderer>();
            if (obj.material.color == Color.black)
                obj.material.color = Color.white;
            else
                obj.material.color = Color.black;

        }
    }
}
