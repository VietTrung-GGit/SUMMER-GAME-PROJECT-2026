using UnityEngine;
[CreateAssetMenu(fileName = "IncreaseBalance", menuName = "ConfirmActions/IncreaseBalance")]
public class IncreaseBalanceAction : BalanceConfirmAction
{
    public override void ExecuteAction(double amount)
    {
        balanceTracker.StatCount += amount;
        //viewTracker.StatCount -= amount;
    }
}