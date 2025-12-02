using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerAnimation : MonoBehaviour
{
    [SerializeField] private InputActionReference activateActionLeft;
    [SerializeField] private InputActionReference activateActionRight;
    private int hand = 0;
    public Material camMaterial;
    public Material blackMaterial;
    public Camera cam;
    Renderer obj;
    private void OnEnable()
    {
        activateActionLeft.action.Enable();
    }

    private void OnDisable()
    {
        activateActionLeft.action.Disable();
    }

    private void Start()
    {
        Renderer obj = GetComponentsInChildren<Transform>()[1].GetComponent<Renderer>();
        if (obj.material == camMaterial)
        {
            obj.material = blackMaterial;
            cam.gameObject.SetActive(false);
        }
        print(obj.material);
        print(camMaterial);
    }

    private void Update()
    {
        if (activateActionRight.action.WasPressedThisFrame() && hand == 1)
        {
            if (obj.material == camMaterial)
            {
                obj.material = blackMaterial;
                cam.gameObject.SetActive(false);
            }
            else
            {
                obj.material = camMaterial;
                cam.gameObject.SetActive(true);
            }
        }
        if (activateActionLeft.action.WasPressedThisFrame() && hand == -1)
        {
            if (obj.material == camMaterial)
            {
                obj.material = blackMaterial;
                cam.gameObject.SetActive(false);
            }
            else
            {
                obj.material = camMaterial;
                cam.gameObject.SetActive(true);
            }
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
