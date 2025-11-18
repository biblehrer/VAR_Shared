using UnityEngine;
using UnityEngine.Networking;

public class WebTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SendData("https://api.github.com/users/biblehrer");
    }

    public async void GetData(string url)
    {
        UnityWebRequest req = new UnityWebRequest(url, "GET");
        req.downloadHandler = new DownloadHandlerBuffer();
        await req.SendWebRequest();    
        string response = req.downloadHandler.text;
        Debug.Log(response);    
    }

    public async void SendData(string url)
    {
        UnityWebRequest req = new UnityWebRequest(url, "GET");
        await req.SendWebRequest();     
    }


}
