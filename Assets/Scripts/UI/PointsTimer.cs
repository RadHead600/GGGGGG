using System;
using System.Collections;
using UnityEngine;

public class PointsTimer : Singleton<PointsTimer>
{

    private float _time;
    private float _startTime;
    private Coroutine _timerCoroutine;

    public float RemainingTimeInProcent { get; private set; }

    public event Action<float> OnTimerUpdate;

    public void StartTimer(float time)
    {
        _time = time;
        _startTime = time;
        _timerCoroutine = StartCoroutine(TimerUpdate());
        LevelProgress.Instance.OnCompletedLevel += StopTimer;
        LevelProgress.Instance.OnCompletedLevel += TakeUpgradePoints.Instance.TakeGems;
    }

    public void StopTimer()
    {
        StopCoroutine(_timerCoroutine);
        RemainingTimeInProcent = GetPercentOfTotalTime();
        LevelProgress.Instance.OnCompletedLevel -= TakeUpgradePoints.Instance.TakeGems;
        LevelProgress.Instance.OnCompletedLevel -= StopTimer;
    }

    private IEnumerator TimerUpdate()
    {
        private float updateInterval = 1f; 
        
        private float minimumTimeValue = 0f;

        private float timeToSubtract = 1f;

        private float remainingTimeThreshold = 0f;
        
        yield return new WaitForSeconds(updateInterval);
        _time -= timeToSubtract;
        
        if (_time <= minimumTimeValue)
        {
            OnTimerUpdate?.Invoke(remainingTimeThreshold);
            yield break;
        }
        
        OnTimerUpdate?.Invoke(GetPercentOfTotalTime());
        _timerCoroutine = StartCoroutine(TimerUpdate());
    }

    private float GetPercentOfTotalTime()
    {
        private float maxPercentage = 1f;
        
        return maxPercentage - ((_startTime - _time) / _startTime);
    }

    private void OnDestroy()
    {
        LevelProgress.Instance.OnCompletedLevel -= StopTimer;
    }
}
