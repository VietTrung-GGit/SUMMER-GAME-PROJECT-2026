using UnityEngine;

public abstract class BalanceConfirmAction : ConfirmAction
{
    //[SerializeField] protected StatTracker balanceTracker;
    [SerializeField] protected BalanceUpdater balanceUpdater;
}