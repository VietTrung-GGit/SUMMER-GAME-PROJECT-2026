using UnityEngine;

public abstract class ConfirmAction : ScriptableObject
{
    [SerializeField] protected StatTracker viewTracker;
    [SerializeField] protected StatTracker likeTracker;
    [SerializeField] protected BalanceTracker balanceTracker;
    public abstract void ExecuteAction(double amount);
}