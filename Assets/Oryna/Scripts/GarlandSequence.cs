using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlandSequence : MonoBehaviour
{
    [Header("Bulbs in order (7 items)")]
    public List<BulbEmission> bulbs = new List<BulbEmission>();

    [Header("Timing")]
    public float interval = 1.0f;       // раз в 1 сек следующая лампочка
    public float onTime = 0.15f;        // сколько горит лампочка внутри этой секунды

    [Header("Loop")]
    public bool loopForever = true;

    [Header("Auto start")]
    public bool playOnStart = true;

    Coroutine routine;

    private void Start()
    {
        if (playOnStart) Play();
    }

    public void Play()
    {
        Stop();
        routine = StartCoroutine(Run());
    }

    public void Stop()
    {
        if (routine != null) StopCoroutine(routine);
        routine = null;
        AllOff();
    }

    public void AllOff()
    {
        foreach (var b in bulbs)
            if (b != null) b.SetOn(false);
    }

    IEnumerator Run()
    {
        if (bulbs == null || bulbs.Count == 0) yield break;

        int i = 0;

        while (loopForever)
        {
            AllOff();

            var b = bulbs[i];
            if (b != null)
            {
                b.SetOn(true);
                yield return new WaitForSeconds(onTime);
                b.SetOn(false);
            }

            // ждём остаток до полной секунды
            float rest = Mathf.Max(0f, interval - onTime);
            yield return new WaitForSeconds(rest);

            i = (i + 1) % bulbs.Count;
        }

        routine = null;
    }
}
