using System.Collections.Generic;
using UnityEngine;

public class BadAdBuilder : AdBuilder
{
    [SerializeField] private Sprite newIcon;
    [SerializeField] private List<ConfirmAction> confirmActionPool;
    [SerializeField] private List<AdItem> adItemPool;
    public override void BuildTitleIcon(Ad targetAd)
    {
        targetAd.SetTitleIcon(newIcon);
    }

    public override void BuildActionIcon(Ad targetAd)
    {
        targetAd.SetActionIcon(newIcon);
    }

    public override void BuildConfirmAction(Ad targetAd)
    {
        int itemIndex = Random.Range(0, adItemPool.Count);
        List<AdAction> targetActionList = adItemPool[itemIndex].AdItemActionList;
        int actionIndex = Random.Range(0, targetActionList.Count);
        targetAd.SetConfirmAction(targetActionList[actionIndex].AdConfirmAction.ExecuteAction, adItemPool[itemIndex].AdItemValue);
    }
}