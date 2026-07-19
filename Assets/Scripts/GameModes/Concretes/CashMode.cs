using System.Collections.Generic;
using UnityEngine;
public class CashMode : GameModeRuntime
{
    [SerializeField] private List<AdItem> adItemList;
    [SerializeField] private List<float> adWeightList;
    [SerializeField] private AdBuilder adBuilder;

    public override void InitializeGameMode()
    {
        if (adBuilder)
        {
            adBuilder.SetUpAdItemDataSet(adItemList, adWeightList);
        }

        int index = 0;
        foreach (RectTransform child in CustomModeUIChildren)
        {
            Transform targetParentUI = CanvasZoneRegistry.Instance.GetTargetUIContainer(UIChildrenTargetZones[index]);
            child.SetParent(targetParentUI);
            child.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            if (IsActiveUIChildren[index])
            {
                child.gameObject.SetActive(true);
            }
            index++;
        }
    }
}