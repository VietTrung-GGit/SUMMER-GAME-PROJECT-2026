using UnityEngine;
[CreateAssetMenu(fileName = "DynamicAdItem", menuName = "AdItem/DynamicAdItem")]
public class DynamicAdItem : AdItem
{
    [SerializeField] private StatTracker priceModifierTracker;
    public override double AdItemValue => value * priceModifierTracker.StatCount;
}
