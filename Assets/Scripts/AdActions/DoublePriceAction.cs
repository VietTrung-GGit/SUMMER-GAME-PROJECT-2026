using UnityEngine;
//MAYBE
[CreateAssetMenu(fileName = "DoublePrice", menuName = "AdButtonActions/DoublePrice")]
public class DoublePriceAction : ModifierConfirmAction
{
    public override void ExecuteAction(double amount)
    {
        //viewTracker.StatCount += amount;
        modifierTracker.StatCount *= amount;
    }
    public override void UpdateViewCount(double viewValue)
    {
        GameCountManager.Instance.UpdateViewCount(viewValue);
    }

    public override void UpdateLikeCount(double likeValue)
    {
        GameCountManager.Instance.UpdateLikeCount(likeValue);
    }
}