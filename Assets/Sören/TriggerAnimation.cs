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
            GetComponentsInChildren<Transform>()[1].GetComponent<Renderer>().material.color = Color.white;
            print(GetComponentsInChildren<Transform>()[1].name);
            print(GetComponentsInChildren<Transform>()[1].GetComponent<Renderer>().material.color);
            print("Action");

        }
    }
}
