using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour, IAmTimer
{
    public event Action OnTimerEnd;

    public void StartTimer(float time)
    {
        StopAllCoroutines();
       StartCoroutine(TimerCorountine(time));
    }

    private IEnumerator TimerCorountine(float time)
    {
        yield return new WaitForSeconds(time);
        print(time);
        OnTimerEnd?.Invoke();
    }

    public void StopTimer()
    {
        StopAllCoroutines();
    }
}
