using System;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    //[SerializeField] private StatTracker speedModifierTracker;
    //[SerializeField] private TimeTracker gameTimeTracker;
    [SerializeField] private StatTracker healthTracker;
    private void OnEnable()
    {
        //speedModifierTracker.OnStatCountChanged += OnSpeedModifierChanged;
        //gameTimeTracker.OnTimeCountExpired += OnGameTimerExpired;
        healthTracker.OnStatCountChanged += OnZeroHealth;
    }

    private void OnDisable()
    {
        //speedModifierTracker.OnStatCountChanged -= OnSpeedModifierChanged;
        //gameTimeTracker.OnTimeCountExpired -= OnGameTimerExpired;
        healthTracker.OnStatCountChanged -= OnZeroHealth;
    }
    /*private void OnSpeedModifierChanged(double amount)
    {
        Time.timeScale = (float) amount;
    }*/

    /*private void OnGameTimerExpired()
    {
        Time.timeScale = 0.0f;
    } */

    private void OnZeroHealth(double amount)
    {
        if (Math.Abs(amount) < 1e-9)
        {
            Time.timeScale = 0.0f;
        }
    }
}