using UnityEngine;
using UnityEngine.UI;
//[CreateAssetMenu(fileName = "AdItem", menuName = "Ad/AdItem")]
public abstract class AdItem : ScriptableObject
{
    [SerializeField] private Image icon;
    [SerializeField] protected double value;
    [SerializeField] private AdAction adAction;
    //[SerializeField] private StatTracker priceModifierTracker;
    [SerializeField] private ViewValue viewValue;
    [SerializeField] private LikeValue likeValue;
    public Sprite AdItemIcon => icon.sprite;
    public abstract double AdItemValue {get;}
    public AdAction AdItemAction => adAction;
    public ViewValue AdItemViewValue => viewValue;
    public LikeValue AdItemLikeValue => likeValue;
}
