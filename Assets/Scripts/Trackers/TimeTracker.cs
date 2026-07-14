using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TimeTracker", menuName = "Trackers/TimeTracker")]
public class TimeTracker : ScriptableObject
{
    [SerializeField] private double timeCount;
    [SerializeField] private double startTimeCount;
    [SerializeField] private double maxTimeCount;
    public double TimeCount
    {
        get => timeCount;
        set
        {
            if (value >= maxTimeCount)
            {
                timeCount = maxTimeCount;
            }
            else
            {
                timeCount = value;
            }
            OnTimeCountChanged?.Invoke(timeCount);
            if (timeCount <= 0.0f)
            {
                OnTimeCountExpired?.Invoke();
                //timeCount = startTimeCount;
            }
        }
    }

    public event Action<double> OnTimeCountChanged;
    public event Action OnTimeCountExpired;

    public void ResetTimer()
    {
        timeCount = startTimeCount;
    }

    private void OnEnable()
    {
        timeCount = startTimeCount;
    }

    private void OnValidate()
    {
        timeCount = startTimeCount;
    }

}