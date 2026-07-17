using System;
using UnityEngine;
//MAYBE
public class PriceModifierUpdater : MonoBehaviour
{
    [SerializeField] private StatTracker priceModifierTracker;
    [SerializeField] private TimeTracker priceModTimeTracker;
    [SerializeField] private GameObject priceModifier;
    private const double REGULAR_MODIFIER = 1.0f;
    private void OnEnable()
    {
        priceModifierTracker.OnStatCountChanged += OnModifierChanged;
        priceModTimeTracker.OnTimeCountExpired += OnTimerExpired;
    }

    private void OnDisable()
    {
        priceModifierTracker.OnStatCountChanged -= OnModifierChanged;
        priceModTimeTracker.OnTimeCountExpired -= OnTimerExpired;
    }

    private void Update()
    {
        if (!priceModifier.activeSelf)
        {
            return;
        }
        priceModTimeTracker.TimeCount -= Time.deltaTime;
    }
    private void OnModifierChanged(double amount)
    {
        //Could this be decoupled?
        priceModTimeTracker.ResetTimer();
        if (!priceModifier.activeSelf && Math.Abs(priceModifierTracker.StatCount - 1.0f) > 1e-9)
        {
            priceModifier.SetActive(true);
        }
    }

    private void OnTimerExpired()
    {
        priceModifierTracker.StatCount = REGULAR_MODIFIER;
    }
}