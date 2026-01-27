using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OllisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Event1"))
        {
            Debug.Log("Klappt");
            TMP_Text textComponent = collision.gameObject.GetComponent<TMP_Text>();
            if (textComponent != null)
            {
                textComponent.text = "Klappt";
            }
        }
    }
}
