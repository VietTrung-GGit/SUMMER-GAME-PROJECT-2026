using System;
using System.Collections.Generic;
using UnityEngine;

public class GoodAdBuilder : AdBuilder
{
    [SerializeField] private Sprite newIcon;
    [SerializeField] private List<ConfirmAction> confirmActionPool;
    private const string AD_BUY_PRODUCT_KEYWORD = "AdBuyTime";
    private const string AD_GAIN_TIME_KEYWORD = "AdGainTime";
    private string currentAdType = AD_BUY_PRODUCT_KEYWORD;
    private readonly Dictionary<string, float> goodAdWeightList = new Dictionary<string, float>()
    {
        {AD_GAIN_TIME_KEYWORD, 0.1f},
        {AD_BUY_PRODUCT_KEYWORD, 0.9f}
    };

    public void RandomizeAdType()
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
    }
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
        //int index = UnityEngine.Random.Range(0,confirmActionPool.Count);
        if (String.Equals(currentAdType, AD_BUY_PRODUCT_KEYWORD))
        {
            targetAd.SetConfirmAction(confirmActionPool[0].ExecuteAction, 100);
        }
        else if (String.Equals(currentAdType, AD_GAIN_TIME_KEYWORD))
        {
            targetAd.SetConfirmAction(confirmActionPool[1].ExecuteAction, 5);
        }
    }

}