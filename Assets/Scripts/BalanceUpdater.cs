using System;
using UnityEngine;

public class BalanceUpdater : MonoBehaviour
{
    [SerializeField] private float intervalMax;
    [SerializeField] private float animationSpeed = 5.0f;
    [SerializeField] private double fixedIncrement = 1;
    [SerializeField] private StatTracker balanceTracker;
    private float intervalRemaining;
    private double trueCount;
    private double targetCount;
    //private const double BALANCE_MAX_VALUE = 999999999;
    private void Awake()
    {
        intervalRemaining = intervalMax;
        trueCount = balanceTracker.StatCount;
        targetCount = trueCount;

    }
    private void Update()
    {
        intervalRemaining -= Time.deltaTime;
        if (intervalRemaining <= 0.0f)
        {
            UpdateBalanceCount(fixedIncrement);
            intervalRemaining = intervalMax;
        }
        //Animation frame by frame for StatCount reaching the targetCount (like Youtube)
        double difference = targetCount - balanceTracker.StatCount;
        if (Math.Abs(difference) > 0.05f)
        {
            balanceTracker.StatCount += difference*animationSpeed*Time.deltaTime;
        }
        else if (balanceTracker.StatCount != targetCount)
        {
            balanceTracker.StatCount = targetCount;
        }
    }
    public void UpdateBalanceCount(double amount)
    {
        trueCount += amount;
        targetCount = trueCount;
    }
}
