using System.Collections.Generic;
using UnityEngine;
public class CashMode : GameModeRuntime
{
    [SerializeField] private List<AdItem> adItemList;
    [SerializeField] private List<float> adWeightList;

    public override void InitializeGameMode()
    {
        GameModeLoader.Instance.SetUpAdBuilder(adItemList, adWeightList);
        GameModeLoader.Instance.ActivateAdSpawner();

        int index = 0;
        foreach (RectTransform child in CustomModeUIChildren)
        {
            Transform targetParentUI = GameModeLoader.Instance.GetTargetUITransform(UIChildrenTargetZones[index]);
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