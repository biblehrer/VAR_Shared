using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public InputActionReference shootActionRight;
    public InputActionReference shootActionLeft;
    public GameObject bull;
    public Transform pos;
    public GameObject door;

    private float timer = 2f;
    public ParticleSystem particle;

    private void OnEnable()
    {
        shootActionLeft.action.Enable();
        shootActionRight.action.Enable();
    }

    private void OnDisable()
    {
        shootActionLeft.action.Disable();
        shootActionRight.action.Disable();
    }

    void Update()
    {
        if ((shootActionLeft.action.WasPressedThisFrame() || shootActionRight.action.WasPressedThisFrame()) && timer < 0)
        {
            Shoot();
            timer = 2f;
        }
        timer -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject go = Instantiate(bull, pos.position, Quaternion.identity);
        go.GetComponent<Bullet>().gun = this;
        go.GetComponent<Bullet>().door = door;
        go.GetComponent<Bullet>().particle = particle;
        Destroy(go, 5);
    }
}
