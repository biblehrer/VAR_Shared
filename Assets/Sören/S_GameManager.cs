using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FigurePosition
{
    public bool[] figPos;
}

public class S_GameManager : MonoBehaviour
{
    public static S_GameManager Instance;
    [HideInInspector]
    public List<Action> DetMe = new List<Action>();

    public bool[] finishedLvl = new bool[10];
    public List<GameObject> lvlSet = new();
    public List<FigurePosition> figPos = new();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void CheckFigPos(int index)
    {
        if (index < 0 || index >= figPos.Count)
            return;

        foreach (var i in figPos[index].figPos)
        {
            if (!i)
                return;
        }

        if (index < finishedLvl.Length)
            finishedLvl[index] = true;

        if (index < DetMe.Count && DetMe[index] != null)
            DetMe[index]();

        switch (index)
        {
            case 0:
                print("case0");
                break;
        }
    }
}

