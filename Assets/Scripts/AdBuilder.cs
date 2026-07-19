using UnityEngine;
using System.Collections.Generic;

public class AdBuilder : MonoBehaviour
{
    [SerializeField] private List<AdItem> adItemPool;
    [SerializeField] private List<float> adWeightList;
    private int targetItemIndex = 0;

    public void SetUpAdItemDataSet(List<AdItem> newList, List<float> newWeightList)
    {
        if (newList.Count > 0)
        {
            adItemPool.Clear();
            adItemPool.AddRange(newList);
        }

        if (newWeightList.Count > 0)
        {
            adWeightList.Clear();
            adWeightList.AddRange(newWeightList);
        }
    }
    public void Randomize()
    {
        //targetItemIndex = Random.Range(0, adItemPool.Count);
        float randomFloat = Random.Range(0.0f, 1.0f);
        float cumulativeProbability = 0.0f;
        for (int index = 0; index < adWeightList.Count; index++)
        {
            cumulativeProbability += adWeightList[index];
            if (cumulativeProbability >= randomFloat)
            {
                targetItemIndex = index;
                break;
            }
        }
    }

    public void BuildAdTimer(Ad targetAd)
    {
        AdExecuteAction targetAdTimerAction = adItemPool[targetItemIndex].AdItemMetadata? adItemPool[targetItemIndex].AdItemMetadata.AdTimerAction : null;
        targetAd.SetAdTimer(adItemPool[targetItemIndex].AdLifetime, targetAdTimerAction? targetAdTimerAction.ExecuteAction : null, adItemPool[targetItemIndex].AdItemValue);
    }
    public void BuildIcon(Ad targetAd)
    {
        targetAd.SetTitleIcon(adItemPool[targetItemIndex].AdItemIcon);
    }

    public void BuildAdButtonActions(Ad targetAd)
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