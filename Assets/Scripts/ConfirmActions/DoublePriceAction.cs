using UnityEngine;
[CreateAssetMenu(fileName = "DoublePrice", menuName = "ConfirmActions/DoublePrice")]
public class DoublePriceAction : ModifierConfirmAction
{
    public override void ExecuteAction(double amount)
    {
        viewTracker.StatCount += amount;
        modifierTracker.StatCount *= amount;
    }
}