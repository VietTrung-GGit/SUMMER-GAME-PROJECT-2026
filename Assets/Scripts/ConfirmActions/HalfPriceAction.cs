using UnityEngine;
[CreateAssetMenu(fileName = "HalfPrice", menuName = "ConfirmActions/HalfPrice")]
public class HalfPriceAction : ModifierConfirmAction
{
    public override void ExecuteAction(double amount)
    {
        //viewTracker.StatCount += amount;
        modifierTracker.StatCount /= amount;
        Debug.Log("Mod divided!");
    }

    public override void UpdateViewCount(ViewValue viewValue)
    {
        GameCountManager.Instance.UpdateViewCount((int)viewValue);
    }

    public override void UpdateLikeCount(LikeValue likeValue)
    {
        GameCountManager.Instance.UpdateLikeCount((int)likeValue);
    }
}