using UnityEngine;
//DISCARDED
[CreateAssetMenu(fileName = "HalfPrice", menuName = "AdButtonActions/HalfPrice")]
public class HalfPriceAction : ModifierConfirmAction
{
    public override void ExecuteAction(double amount)
    {
        //viewTracker.StatCount += amount;
        modifierTracker.StatCount /= amount;        
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