using UnityEngine;
[CreateAssetMenu(fileName = "DecreaseTime", menuName = "ConfirmActions/DecreaseTime")]
public class DecreaseTimeAction : ConfirmAction
{
    public override void ExecuteAction(double amount)
    {
        //viewTracker.StatCount -= amount;
        //gameTimeTracker.TimeCount -= amount;
        //gameTimerUpdater.UpdateGameTime(-amount);
        GameCountManager.Instance.UpdateGameTimeCount(-amount);
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