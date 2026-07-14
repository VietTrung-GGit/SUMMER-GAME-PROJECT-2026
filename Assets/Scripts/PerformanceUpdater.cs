using System;
using UnityEngine;

public class PerformanceUpdater : MonoBehaviour
{
    [SerializeField] private float intervalMax;
    [SerializeField] private float animationSpeed = 5.0f;
    [SerializeField] private double fixedIncrement = 1;
    [SerializeField] private StatTracker performanceTracker;
    private float intervalRemaining;
    private double trueCount;
    private double targetCount;
    //private const double STAT_MAX_VALUE = 999999999999;
    private void Awake()
    {
        intervalRemaining = intervalMax;
        trueCount = performanceTracker.StatCount;
        targetCount = trueCount;

    }
    private void Update()
    {
        intervalRemaining -= Time.deltaTime;
        if (intervalRemaining <= 0.0f)
        {
            UpdateStatCount(fixedIncrement);
            intervalRemaining = intervalMax;
        }

        double difference = targetCount - performanceTracker.StatCount;
        if (Math.Abs(difference) > 0.05f)
        {
            performanceTracker.StatCount += difference*animationSpeed*Time.deltaTime;
        }
        else if (performanceTracker.StatCount != targetCount)
        {
            performanceTracker.StatCount = targetCount;
        }
    }

    public void UpdateStatCount(double amount)
    {
        trueCount += amount;
        if (trueCount < 0.0f)
        {
            trueCount = 0.0f;
        }
        targetCount = trueCount;
    }

}