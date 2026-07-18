using System.Collections.Generic;
using UnityEngine;

public abstract class GameModeRuntime : MonoBehaviour
{
    [SerializeField] protected List<RectTransform> CustomModeUIChildren;
    [SerializeField] protected List<UITargetZone> UIChildrenTargetZones;

    [SerializeField] protected List<bool> IsActiveUIChildren;

    public void InitializeGameMode()
    {
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

    public void DestroyGameMode()
    {
        foreach (RectTransform child in CustomModeUIChildren)
        {
            Destroy(child.gameObject);
        }
        Destroy(gameObject);
    }

}