using UnityEngine;

public abstract class ConfirmAction : ScriptableObject
{
    [SerializeField] protected StatTracker viewTracker;
    public abstract void ExecuteAction(double amount);
}