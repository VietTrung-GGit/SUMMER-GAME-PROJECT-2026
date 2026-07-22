using UnityEngine;
[CreateAssetMenu(fileName = "IncreaseBalance", menuName = "AdActions/IncreaseBalance")]
public class IncreaseBalanceAction : AdExecuteAction
{
    public override void ExecuteAction(double amount)
    {
        //balanceTracker.StatCount += amount;
        //viewTracker.StatCount -= amount;
        //balanceUpdater.UpdateBalanceCount(amount);
        CashModeCountManager.Instance.UpdateBalanceCount(amount);
    }

    public override void UpdateViewCount(double viewValue)
    {
        GameCountManager.Instance.UpdateViewCount(-viewValue);
    }

    public override void UpdateLikeCount(double likeValue)
    {
        GameCountManager.Instance.UpdateLikeCount(-likeValue);
    }
}