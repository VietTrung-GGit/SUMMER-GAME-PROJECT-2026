using System;
using UnityEngine;

public class BalanceUpdate : MonoBehaviour
{
    [SerializeField] private float intervalMax;
    [SerializeField] private float animationSpeed = 5.0f;
    [SerializeField] private double fixedIncrement = 1;
    [SerializeField] private StatTracker balanceTracker;
    private float intervalRemaining;
    private double targetCount = 1000000;
    //private const double BALANCE_MAX_VALUE = 999999999;
    private void Awake()
    {
        intervalRemaining = intervalMax;

    }
    private void Update()
    {
        intervalRemaining -= Time.deltaTime;
        if (intervalRemaining <= 0.0f)
        {
            UpdateBalanceCount(fixedIncrement);
            intervalRemaining = intervalMax;
        }

        if (Math.Abs(targetCount - balanceTracker.StatCount) > 0.05f)
        {
            balanceTracker.StatCount += (targetCount - balanceTracker.StatCount)*animationSpeed*Time.deltaTime;
        }
        else if (!Double.Equals(balanceTracker.StatCount, targetCount))
        {
            balanceTracker.StatCount = targetCount;
        }
    }
    public void UpdateBalanceCount(double increment)
    {
        targetCount = balanceTracker.StatCount + increment;
    }
}
