using System.Collections.Generic;
using UnityEngine;

public abstract class GameModeRuntime : MonoBehaviour
{
    [SerializeField] protected List<RectTransform> CustomModeUIChildren;
    [SerializeField] protected List<UITargetZone> UIChildrenTargetZones;
    [SerializeField] protected List<bool> IsActiveUIChildren;

    public abstract void InitializeGameMode();

    public void DestroyGameMode()
    {
        foreach (RectTransform child in CustomModeUIChildren)
        {
            Destroy(child.gameObject);
        }
        Destroy(gameObject);
    }

}