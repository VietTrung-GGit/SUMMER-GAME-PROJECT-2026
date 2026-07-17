using UnityEngine;

public class HealthUpdater : MonoBehaviour
{
    [SerializeField] private StatTracker healthTracker;

    public void UpdateHealth(double amount)
    {
        healthTracker.StatCount += amount;
    }
}