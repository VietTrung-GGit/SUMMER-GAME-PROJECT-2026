using UnityEngine;
[CreateAssetMenu(fileName = "IncreaseBalance", menuName = "ConfirmActions/IncreaseBalance")]
public class IncreaseBalanceAction : ConfirmAction
{
    public override void ExecuteAction(double amount)
    {
        //balanceTracker.StatCount += amount;
        //viewTracker.StatCount -= amount;
        //balanceUpdater.UpdateBalanceCount(amount);
        GameCountManager.Instance.UpdateBalanceCount(amount);
    }

    public override void UpdateViewCount(ViewValue viewValue)
    {
        GameCountManager.Instance.UpdateViewCount(-(int)viewValue);
    }

    public override void UpdateLikeCount(LikeValue likeValue)
    {
        GameCountManager.Instance.UpdateLikeCount(-(int)likeValue);
    }
}