using UnityEngine;

public class CubeSaver : MonoBehaviour
{
    public bool isBlue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        SaveManager.loadedSave += ReactToSave;
        SaveManager.saving += ReactToSaving;
    }

    void OnDisable()
    {
        SaveManager.loadedSave -= ReactToSave;
        SaveManager.saving -= ReactToSaving;
    }

    public void ReactToSave(SaveFile file)
    {
        Debug.Log("file recieved");
        if (isBlue)
        {
            transform.position = file.blue;
        }
        else
        {
            transform.position = file.red;
        }
    }

    public void ReactToSaving()
    {
        if (isBlue)
        {
            SaveManager.saveFile.blue = transform.position;
        }
        else
        {
            SaveManager.saveFile.red = transform.position;
        }
        Debug.Log("Saving");
    }
}
