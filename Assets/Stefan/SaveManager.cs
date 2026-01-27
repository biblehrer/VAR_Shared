using System;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static Action<SaveFile> loadedSave;
    public static Action saving;

    public static SaveFile saveFile;
    private float time = 0;

    void Start()
    {
        LoadSave();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > 5)
        {
            CreateSaveFile();
            time -=5;
        }
    }

    public void LoadSave()
    {
        string path = Path.Combine(Application.persistentDataPath, "Save.json");

        if (!File.Exists(path))
        {
            return;
        }

        string JSONasString = File.ReadAllText(path);
        saveFile = JsonUtility.FromJson<SaveFile>(JSONasString);    
        loadedSave?.Invoke(saveFile);

    }

    public void CreateSaveFile()
    {
        saving?.Invoke();
        string path = Path.Combine(Application.persistentDataPath, "Save.json");
        string JSONasString = JsonUtility.ToJson(saveFile, true);
        File.WriteAllText(path, JSONasString);
    }
}
