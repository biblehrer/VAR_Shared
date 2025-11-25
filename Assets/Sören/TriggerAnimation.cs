using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerAnimation : MonoBehaviour
{
    [SerializeField] private InputActionReference activateActionLeft;
    [SerializeField] private InputActionReference activateActionRight;
    private int hand = 0;

    private void OnEnable()
    {
        activateActionLeft.action.Enable();
    }

    private void OnDisable()
    {
        activateActionLeft.action.Disable();
    }

    private void Update()
    {
        if (activateActionRight.action.WasPressedThisFrame() && hand == 1)
        {
            Renderer obj = GetComponentsInChildren<Transform>()[1].GetComponent<Renderer>();
            if (obj.material.color == Color.black)
                obj.material.color = Color.white;
            else
                obj.material.color = Color.black;
        }
        if (activateActionLeft.action.WasPressedThisFrame() && hand == -1)
        {
            Renderer obj = GetComponentsInChildren<Transform>()[1].GetComponent<Renderer>();
            if (obj.material.color == Color.black)
                obj.material.color = Color.white;
            else
                obj.material.color = Color.black;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Left Controller")
            hand = -1;
        else if (other.gameObject.name == "Right Controller")
            hand = 1;
    }
}
