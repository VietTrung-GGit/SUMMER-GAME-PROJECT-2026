using UnityEngine;
[CreateAssetMenu(fileName = "DecreaseTime", menuName = "ConfirmActions/DecreaseTime")]
public class DecreaseTimeAction : TimeConfirmAction
{
    public override void ExecuteAction(double amount)
    {
        viewTracker.StatCount -= amount;
        gameTimerTracker.StatCount -= amount;
    }
}