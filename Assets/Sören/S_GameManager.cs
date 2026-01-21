using System.Collections.Generic;
using UnityEngine;

public delegate void EventHandler();
public class S_GameManager : MonoBehaviour
{
    public static S_GameManager Instance;
    public List<EventHandler> DetMe = new List<EventHandler>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public bool[] finishedLvl = new bool[10];
    public List<bool[]> figPos = new List<bool[]>
    {
        new bool[5],
    };


    public void CheckFigPos(int index)
    {
        foreach (var i in figPos[index])
        {
            if (!i)
                return;
        }

        finishedLvl[index] = true;
        DetMe[index]();

        switch (index)
        {
            case 0:
                // Do something
                break;
        }
    }
}
