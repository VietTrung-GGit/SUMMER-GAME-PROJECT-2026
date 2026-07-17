using UnityEngine;

public class GameTimeUpdater : MonoBehaviour
{
    [SerializeField] private TimeTracker gameTimeTracker;
    private void OnEnable()
    {
        gameTimeTracker.OnTimeCountExpired += OnGameTimeExpired;
    }

    private void OnDisable()
    {
        gameTimeTracker.OnTimeCountExpired -= OnGameTimeExpired;
    }
    private void Update()
    {
        gameTimeTracker.TimeCount -= Time.deltaTime;
    }

    public void UpdateGameTime(double amount)
    {
        gameTimeTracker.TimeCount += amount;
    }

    private void OnGameTimeExpired()
    {
        gameTimeTracker.ResetTimer();
    }
}