using UnityEngine;
//MAYBE
[CreateAssetMenu(fileName = "DoublePrice", menuName = "AdActions/DoublePrice")]
public class DoublePriceAction : ModifierConfirmAction
{
    public override void ExecuteAction(double amount)
    {
        //viewTracker.StatCount += amount;
        modifierTracker.StatCount *= amount;
    }
    public override void UpdateViewCount(double viewValue)
    {
        BaseGameCountManager.Instance.UpdateViewCount(viewValue);
    }

    public override void UpdateLikeCount(double likeValue)
    {
        BaseGameCountManager.Instance.UpdateLikeCount(likeValue);
    }
}