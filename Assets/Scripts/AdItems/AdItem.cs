using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "AdItem", menuName = "Ad/AdItem")]
public class AdItem : ScriptableObject
{
    [SerializeField] private Image icon;
    [SerializeField] private double value;
    [SerializeField] private List<AdAction> actionList;
    [SerializeField] private StatTracker priceModifierTracker;
    public Sprite AdItemIcon => icon.sprite;
    public double AdItemValue => value * priceModifierTracker.StatCount;
    public List<AdAction> AdItemActionList => actionList;
}
