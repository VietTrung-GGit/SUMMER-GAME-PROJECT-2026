using System;
using UnityEngine;

public class PerformanceUpdate : MonoBehaviour
{
    [SerializeField] private float intervalMax;
    [SerializeField] private float animationSpeed = 5.0f;
    [SerializeField] private double fixedIncrement = 1;
    [SerializeField] private StatTracker performanceTracker;
    private float intervalRemaining;
    private double targetCount = 0;
    //private const double STAT_MAX_VALUE = 999999999999;
    private void Awake()
    {
        intervalRemaining = intervalMax;

    }
    private void Update()
    {
        intervalRemaining -= Time.deltaTime;
        if (intervalRemaining <= 0.0f)
        {
            UpdateStatCount(fixedIncrement);
            intervalRemaining = intervalMax;
        }

        if (Math.Abs(targetCount - performanceTracker.StatCount) > 0.05f)
        {
            performanceTracker.StatCount += (targetCount - performanceTracker.StatCount)*animationSpeed*Time.deltaTime;
        }
        else if (!Double.Equals(performanceTracker.StatCount, targetCount))
        {
            performanceTracker.StatCount = targetCount;
        }
    }

    public void UpdateStatCount(double increment)
    {
        targetCount = performanceTracker.StatCount + increment;
    }

}