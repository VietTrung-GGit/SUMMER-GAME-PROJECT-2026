using UnityEngine;
[CreateAssetMenu(fileName = "DecreaseBalance", menuName = "ConfirmActions/DecreaseBalance")]
public class DecreaseBalanceAction : BalanceConfirmAction
{
    public override void ExecuteAction(double amount)
    {
        balanceTracker.StatCount -= amount;
        //viewTracker.StatCount += amount;
    }
}