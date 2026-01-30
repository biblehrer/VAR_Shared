using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject door;
    public Gun gun;
    public ParticleSystem particle;

    void Update()
    {
        transform.position += Vector3.forward;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Target"))
            {
                Door();
            }
            Destroy(gameObject);
        }
    }

    private void Door()
    {
        door.transform.rotation = Quaternion.Euler(0, 180, 0);
        particle.Play();
    }
}
