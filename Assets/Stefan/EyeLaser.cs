using System;
using UnityEngine;

public class EyeLaser : MonoBehaviour
{
    public static Action<String> laserHit;

    void Update()
    {
        Laser();
    }

    void Laser()
    {
        LayerMask mask = LayerMask.GetMask("EyeLaserTarget");

        bool rc = Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 10000, mask);

        if (rc)
        {
            laserHit?.Invoke(hit.collider.gameObject.name);
        }
        
    }
}
