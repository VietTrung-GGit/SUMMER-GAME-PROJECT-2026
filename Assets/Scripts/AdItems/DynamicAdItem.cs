using UnityEngine;
[CreateAssetMenu(fileName = "DynamicAdItem", menuName = "AdItem/DynamicAdItem")]
public class DynamicAdItem : AdItem
{
    [SerializeField] private StatTracker modifierTracker;
    public override double AdItemValue => value * modifierTracker.StatCount;
    public override double AdItemViewValue => (int)viewValue * modifierTracker.StatCount;
    public override double AdItemLikeValue => (int)likeValue * modifierTracker.StatCount;
}
