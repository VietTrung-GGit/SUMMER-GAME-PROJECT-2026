using UnityEngine;
[CreateAssetMenu(fileName = "StaticAdItem", menuName = "AdItem/StaticAdItem")]
public class StaticAdItem : AdItem
{
    public override double AdItemValue => value;
    public override double AdItemViewValue => (int)viewValue;
    public override double AdItemLikeValue => (int)likeValue;
}
