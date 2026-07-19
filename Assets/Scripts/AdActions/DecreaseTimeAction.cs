using UnityEngine;
//DISCARDED
[CreateAssetMenu(fileName = "DecreaseTime", menuName = "AdActions/DecreaseTime")]
public class DecreaseTimeAction : AdExecuteAction
{
    public override void ExecuteAction(double amount)
    {
        //viewTracker.StatCount -= amount;
        //gameTimeTracker.TimeCount -= amount;
        //gameTimerUpdater.UpdateGameTime(-amount);
        BaseGameCountManager.Instance.UpdateGameTimeCount(-amount);
    }
    public override void UpdateViewCount(double viewValue)
    {
        BaseGameCountManager.Instance.UpdateViewCount(-viewValue);
    }

    public override void UpdateLikeCount(double likeValue)
    {
        BaseGameCountManager.Instance.UpdateLikeCount(-likeValue);
    }
}