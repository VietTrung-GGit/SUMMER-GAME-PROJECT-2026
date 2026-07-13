using System;
using UnityEngine;

public class BalanceCount : MonoBehaviour
{
    [SerializeField] private float intervalMax;
    [SerializeField] private float animationSpeed = 5.0f;
    [SerializeField] private double fixedIncrement = 1;
    //[SerializeField] private double currentCount = 1000000;
    [SerializeField] private BalanceTracker balanceTracker;
    private float intervalRemaining;
    private double targetCount = 1000000;
    private const double BALANCE_MAX_VALUE = 999999999;
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

        if (Math.Abs(targetCount - balanceTracker.Balance) > 0.05f)
        {
            balanceTracker.Balance += (targetCount - balanceTracker.Balance)*animationSpeed*Time.deltaTime;
        }
        else if (!Double.Equals(balanceTracker.Balance, targetCount))
        {
            balanceTracker.Balance = targetCount;
        }
    }
    public void UpdateBalanceCount(double increment)
    {
        targetCount = balanceTracker.Balance + increment;
        if (targetCount > BALANCE_MAX_VALUE)
        {
            targetCount = BALANCE_MAX_VALUE;
        }
    }
}
