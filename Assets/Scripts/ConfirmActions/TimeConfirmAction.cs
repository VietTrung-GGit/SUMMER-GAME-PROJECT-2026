using UnityEngine;

public abstract class TimeConfirmAction : ConfirmAction
{
    //[SerializeField] protected TimeTracker gameTimeTracker;
    [SerializeField] protected GameTimeUpdater gameTimerUpdater;
}