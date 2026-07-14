using UnityEngine;

public class GameTimeUpdater : MonoBehaviour
{
    [SerializeField] private TimeTracker gameTimeTracker;
    private void Update()
    {
        gameTimeTracker.TimeCount -= Time.deltaTime;
    }

    public void UpdateGameTime(double amount)
    {
        gameTimeTracker.TimeCount += amount;
    }
}