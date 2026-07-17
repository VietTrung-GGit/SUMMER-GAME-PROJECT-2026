using UnityEngine;
//DISCARDED
[CreateAssetMenu(fileName = "DecreaseTime", menuName = "AdButtonActions/DecreaseTime")]
public class DecreaseTimeAction : AdExecuteAction
{
    public override void ExecuteAction(double amount)
    {
        //viewTracker.StatCount -= amount;
        //gameTimeTracker.TimeCount -= amount;
        //gameTimerUpdater.UpdateGameTime(-amount);
        GameCountManager.Instance.UpdateGameTimeCount(-amount);
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