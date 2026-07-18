using System.Collections.Generic;
using UnityEngine;

public abstract class GameModeRuntime : MonoBehaviour
{
    [SerializeField] protected List<RectTransform> CustomModeUIChildren;
    [SerializeField] protected List<UITargetZone> UIChildrenTargetZones;

    public void InitializeGameMode()
    {
        int index = 0;
        foreach (RectTransform child in CustomModeUIChildren)
        {
            Transform targetParentUI = CanvasZoneRegistry.Instance.GetTargetUIContainer(UIChildrenTargetZones[index]);
            targetParentUI.SetParent(child);
            child.gameObject.SetActive(true);
            index++;
        }
    }

    public void DestroyGameMode()
    {
        Destroy(gameObject);
    }

}