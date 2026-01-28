using System;
using System.Collections;
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

    public bool[] finishedLvl = new bool[10];
    public List<GameObject> lvlSet = new();
    public List<FigurePosition> figPos = new();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        foreach (var pos in figPos)
        {
            for (int i = 0; i < pos.figPos.Length; i++)
            {
                pos.figPos[i] = false;
            }
        }
    }

    public void CheckFigPos(int index)
    {
        print("Check for " + index);

        if (index < 0 || index >= figPos.Count)
            return;

        foreach (var i in figPos[index].figPos)
        {
            if (!i)
                return;
        }

        if (index < finishedLvl.Length)
            finishedLvl[index] = true;

        switch (index)
        {
            case 0:
                StartCoroutine(KillObject(2f, lvlSet[0]));
                print("case0");
                break;
        }
    }

    private IEnumerator KillObject(float sec, GameObject obj)
    {
        yield return new WaitForSeconds(sec);
        Destroy(obj);
    }
}

