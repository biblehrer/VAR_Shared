using UnityEngine;

public class SimpleOutline : MonoBehaviour
{
    public float size = 1.05f;

    void Start()
    {
        GameObject outline = Instantiate(gameObject, transform.position, transform.rotation, transform);
        outline.transform.localScale *= size;

        var rend = outline.GetComponent<Renderer>();
        rend.material = new Material(Shader.Find("Unlit/Color"));
        rend.material.color = Color.red;

        Destroy(outline.GetComponent<Collider>());
        Destroy(outline.GetComponent<SimpleOutline>());
    }
}
