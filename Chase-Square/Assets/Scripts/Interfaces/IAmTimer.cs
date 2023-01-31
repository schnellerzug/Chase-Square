using System;

internal interface IAmTimer
{
    public event Action OnTimerEnd;
    public void StartTimer(float time);
    public void StopTimer();
}