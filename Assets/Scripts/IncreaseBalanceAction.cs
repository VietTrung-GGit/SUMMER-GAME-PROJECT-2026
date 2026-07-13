public class IncreaseBalanceAction : ConfirmAction
{
    public override void ExecuteAction(double amount)
    {
        balanceTracker.Balance += amount;
    }
}