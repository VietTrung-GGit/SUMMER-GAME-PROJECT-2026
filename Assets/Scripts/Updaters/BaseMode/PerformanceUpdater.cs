using System;
using UnityEngine;

public class PerformanceUpdater : MonoBehaviour
{
    [SerializeField] private float baseIntervalMax;
    [SerializeField] private float animationSpeed = 5.0f;
    [SerializeField] private double fixedIncrement = 1;
    [SerializeField] private StatTracker performanceTracker;
    //[SerializeField] private TimeTracker gameTimeTracker;
    //private const int SPEED_UP_VALUE = 2;
    [SerializeField] private StatTracker speedModifierTracker;
    private float intervalRemaining;
    private float currentIntervalMax;
    private double trueCount;
    private double targetCount;
    //private const double STAT_MAX_VALUE = 999999999999;
    private void Awake()
    {
        currentIntervalMax = baseIntervalMax;
        intervalRemaining = currentIntervalMax;
        trueCount = performanceTracker.StatCount;
        targetCount = trueCount;

    }

    private void OnEnable()
    {
        //gameTimeTracker.OnTimeCountExpired += OnGameTimerExpired;
        speedModifierTracker.OnStatCountChanged += OnSpeedModifierChanged;
    }

    private void OnDisable()
    {
        //gameTimeTracker.OnTimeCountExpired -= OnGameTimerExpired;
        speedModifierTracker.OnStatCountChanged -= OnSpeedModifierChanged;
    }

    private void Update()
    {
        intervalRemaining -= Time.deltaTime;
        if (intervalRemaining <= 0.0f)
        {
            UpdateStatCount(-fixedIncrement);
            intervalRemaining = currentIntervalMax;
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

    private void OnSpeedModifierChanged(double amount)
    {
        currentIntervalMax = baseIntervalMax/(float)amount;
    }

}