using System.Collections.Generic;
using UnityEngine;

public class BadAdBuilder : AdBuilder
{
    //[SerializeField] private Sprite newIcon;
    //[SerializeField] private List<ExecuteAction> confirmActionPool;
    [SerializeField] private List<AdItem> adItemPool;
    private int targetItemIndex = 0;
    public override void Randomize()
    {
        targetItemIndex = Random.Range(0, adItemPool.Count);
    }

    public override void BuildAdTimer(Ad targetAd)
    {
        AdExecuteAction targetAdTimerAction = adItemPool[targetItemIndex].AdItemMetadata? adItemPool[targetItemIndex].AdItemMetadata.AdTimerAction : null;
        targetAd.SetAdTimer(adItemPool[targetItemIndex].AdLifetime, targetAdTimerAction? targetAdTimerAction.ExecuteAction : null, adItemPool[targetItemIndex].AdItemValue);
    }
    public override void BuildIcon(Ad targetAd)
    {
        targetAd.SetTitleIcon(adItemPool[targetItemIndex].AdItemIcon);
    }

    /*public override void BuildActionIcon(Ad targetAd)
    {
        targetAd.SetActionIcon(newIcon);
    }*/

    public override void BuildAdButtonActions(Ad targetAd)
    {
        if (adItemPool[targetItemIndex].AdItemMetadata)
        {
            AdExecuteAction targetConfirmAction = adItemPool[targetItemIndex].AdItemMetadata.AdConfirmAction;
            AdAction targetCloseAction = adItemPool[targetItemIndex].AdItemMetadata.AdCloseAction;
            targetAd.SetConfirmAction(targetConfirmAction.ExecuteAction, adItemPool[targetItemIndex].AdItemValue);
            targetAd.SetConfirmAction(targetConfirmAction.UpdateViewCount, adItemPool[targetItemIndex].AdItemViewValue);
            targetAd.SetConfirmAction(targetConfirmAction.UpdateLikeCount, adItemPool[targetItemIndex].AdItemLikeValue);
            targetAd.SetCloseButton(targetCloseAction.UpdateViewCount, adItemPool[targetItemIndex].AdItemViewValue);
            targetAd.SetCloseButton(targetCloseAction.UpdateLikeCount, adItemPool[targetItemIndex].AdItemLikeValue);
        }
    }
}