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

    public ParticleSystem system;

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

        for (int i = 0; i < lvlSet.Count; i++)
        {
            if (i > 0)
                lvlSet[i].SetActive(false);
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

        StartCoroutine(DisableObj(2f, index));
    }

    private IEnumerator DisableObj(float sec, int index)
    {
        if (system != null)
            system.Play();

        yield return new WaitForSeconds(sec);

        lvlSet[index].SetActive(false);

        if (index + 1 < lvlSet.Count)
            lvlSet[index + 1].SetActive(true);
        else
            print("Game Finished");
    }
}

