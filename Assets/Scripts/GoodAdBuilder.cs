using System.Collections.Generic;
using UnityEngine;

public class GoodAdBuilder : AdBuilder
{
    //[SerializeField] private Sprite newIcon;
    //[SerializeField] private List<ExecuteAction> confirmActionPool;
    [SerializeField] private List<AdItem> adItemPool;
    private int targetItemIndex = 0;
    /*private const string AD_BUY_PRODUCT_KEYWORD = "AdBuyTime";
    private const string AD_GAIN_TIME_KEYWORD = "AdGainTime";
    private string currentAdType = AD_BUY_PRODUCT_KEYWORD;
    private readonly Dictionary<string, float> goodAdWeightList = new Dictionary<string, float>()
    {
        {AD_GAIN_TIME_KEYWORD, 0.1f},
        {AD_BUY_PRODUCT_KEYWORD, 0.9f}
    };*/

    /*public void RandomizeAdType()
    {
        float randomFloat = UnityEngine.Random.Range(0.0f,1.0f);
        float cumulativeProbability = 0.0f;
        foreach (string key in goodAdWeightList.Keys)
        {
            cumulativeProbability += goodAdWeightList[key];
            if (cumulativeProbability >= randomFloat)
            {
                currentAdType = key;
                break;
            }
        }
    }*/
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
        //List<AdAction> targetActionList = adItemPool[itemIndex].AdItemActionList;
        //int actionIndex = Random.Range(0, targetActionList.Count);
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