using UnityEngine;
[CreateAssetMenu(fileName = "HalfPrice", menuName = "ConfirmActions/HalfPrice")]
public class HalfPriceAction : ModifierConfirmAction
{
    public override void ExecuteAction(double amount)
    {
        //viewTracker.StatCount += amount;
        modifierTracker.StatCount /= amount;
    }
}