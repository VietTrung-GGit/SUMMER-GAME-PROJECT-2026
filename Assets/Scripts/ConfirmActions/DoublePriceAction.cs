using UnityEngine;
[CreateAssetMenu(fileName = "DoublePrice", menuName = "ConfirmActions/DoublePrice")]
public class DoublePriceAction : ModifierConfirmAction
{
    public override void ExecuteAction(double amount)
    {
        //viewTracker.StatCount += amount;
        modifierTracker.StatCount *= amount;
        Debug.Log("Mod multiplied!");
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