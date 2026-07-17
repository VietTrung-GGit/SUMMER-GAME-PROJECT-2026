using System;
using UnityEngine;
//MAYBE
public class OverdraftModifierUpdater : MonoBehaviour
{
    [SerializeField] private StatTracker overdraftModifierTracker;
    [SerializeField] private StatTracker balanceTracker;
    [SerializeField] private TimeTracker overdraftModTimeTracker;
    [SerializeField] private GameObject overdraftModifier;
    private const double REGULAR_MODIFIER = 1.0f;
    private const double MODIFIER_MULTIPLIER = 2.0f;
    private void OnEnable()
    {
        //overdraftModifierTracker.OnStatCountChanged += OnModifierChanged;
        overdraftModTimeTracker.OnTimeCountExpired += OnTimerExpired;
        balanceTracker.OnNegativeStatCount += OnNegativeBalance;
    }

    private void OnDisable()
    {
        //overdraftModifierTracker.OnStatCountChanged -= OnModifierChanged;
        overdraftModTimeTracker.OnTimeCountExpired -= OnTimerExpired;
        balanceTracker.OnNegativeStatCount -= OnNegativeBalance;
    }

    private void Update()
    {
        if (!overdraftModifier.activeSelf)
        {
            return;
        }
        overdraftModTimeTracker.TimeCount -= Time.deltaTime;
    }

    private void OnNegativeBalance()
    {
        if (!overdraftModifier.activeSelf)
        {
            overdraftModifier.SetActive(true);
        }
    }

    private void OnTimerExpired()
    {
        if (balanceTracker.StatCount < 0.0f)
        {
            overdraftModifierTracker.StatCount *= MODIFIER_MULTIPLIER;
            overdraftModTimeTracker.ResetTimer();
        }
        else
        {
            overdraftModifier.SetActive(false);
            overdraftModifierTracker.StatCount = REGULAR_MODIFIER;
        }
        overdraftModTimeTracker.ResetTimer();
    }
}