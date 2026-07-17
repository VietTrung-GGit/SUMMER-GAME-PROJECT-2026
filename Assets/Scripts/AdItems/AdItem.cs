using UnityEngine;
using UnityEngine.UI;
//[CreateAssetMenu(fileName = "AdItem", menuName = "Ad/AdItem")]
public abstract class AdItem : ScriptableObject
{
    [SerializeField] private Sprite icon;
    [SerializeField] protected double value;
    [SerializeField] protected float lifeTime;
    [SerializeField] private AdMetadata adMetadata;
    //[SerializeField] private StatTracker priceModifierTracker;
    [SerializeField] protected ViewValue viewValue;
    [SerializeField] protected LikeValue likeValue;
    public Sprite AdItemIcon => icon;
    public abstract double AdItemValue {get;}
    public float AdLifetime => lifeTime;
    public AdMetadata AdItemMetadata => adMetadata;
    public abstract double AdItemViewValue {get;}
    public abstract double AdItemLikeValue {get;}
}
