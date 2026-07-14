using UnityEngine;
[CreateAssetMenu(fileName = "IncreaseTime", menuName = "ConfirmActions/IncreaseTime")]
public class IncreaseTimeAction : TimeConfirmAction
{
    public override void ExecuteAction(double amount)
    {
        //viewTracker.StatCount += amount;
        gameTimerTracker.StatCount += amount;
    }
}