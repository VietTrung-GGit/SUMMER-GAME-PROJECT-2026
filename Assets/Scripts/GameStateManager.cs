using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private StatTracker speedModifierTracker;
    [SerializeField] private TimeTracker gameTimeTracker;
    private void OnEnable()
    {
        speedModifierTracker.OnStatCountChanged += OnSpeedModifierChanged;
        gameTimeTracker.OnTimeCountExpired += OnGameTimerExpired;
    }

    private void OnDisable()
    {
        speedModifierTracker.OnStatCountChanged -= OnSpeedModifierChanged;
        gameTimeTracker.OnTimeCountExpired -= OnGameTimerExpired;
    }
    private void OnSpeedModifierChanged(double amount)
    {
        Time.timeScale = (float) amount;
    }

    private void OnGameTimerExpired()
    {
        Time.timeScale = 0.0f;
    } 
}