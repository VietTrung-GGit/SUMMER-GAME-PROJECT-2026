using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "AdItem", menuName = "Ad/AdItem")]
public class AdItem : ScriptableObject
{
    [SerializeField] private Image icon;
    [SerializeField] private double value;
    [SerializeField] private AdAction action;
    [SerializeField] private StatTracker priceModifierTracker;
    [SerializeField] private ViewValue viewValue;
    [SerializeField] private LikeValue likeValue;
    public Sprite AdItemIcon => icon.sprite;
    public double AdItemValue => value * priceModifierTracker.StatCount;
    public AdAction AdItemAction => action;
    public ViewValue AdItemViewValue => viewValue;
    public LikeValue AdItemLikeValue => likeValue;
}
