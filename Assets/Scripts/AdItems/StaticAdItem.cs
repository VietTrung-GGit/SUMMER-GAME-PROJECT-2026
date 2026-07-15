using UnityEngine;
[CreateAssetMenu(fileName = "StaticAdItem", menuName = "AdItem/StaticAdItem")]
public class StaticAdItem : AdItem
{
    public override double AdItemValue => value;
}
