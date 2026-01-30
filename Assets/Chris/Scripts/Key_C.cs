using System.Collections;
using UnityEngine;

public class Key_C : MonoBehaviour
{
    public GameObject part;
    public GameObject door;
    private bool openDoor = false;
    private float speed = 5f;
    private float movePerTime;
    private float targetRotation = -130f;

    private void Start()
    {
        movePerTime = speed * Time.fixedDeltaTime;
    }

    private void FixedUpdate()
    {
        if (openDoor)
        {
            float currentY = door.transform.eulerAngles.y;

            // Normalisiere den Winkel (-180 bis 180)
            if (currentY > 180f)
                currentY -= 360f;

            if (currentY > targetRotation)
            {
                float newY = Mathf.Max(currentY - movePerTime, targetRotation);
                door.transform.rotation = Quaternion.Euler(0, newY, 0);
            }
            else
            {
                openDoor = false; // Animation beendet
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Schloss"))
        {
            Destroy(other.gameObject);
            openDoor = true;
            StartCoroutine(DoorAnimation(speed));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(part);
        }
    }

    private IEnumerator DoorAnimation(float sec)
    {
        yield return new WaitForSeconds(sec);
        Destroy(gameObject);
    }
}
