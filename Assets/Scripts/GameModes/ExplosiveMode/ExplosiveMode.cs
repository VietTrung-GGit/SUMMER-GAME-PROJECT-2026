using UnityEngine;
public class ExplosiveMode : GameModeRuntime
{
    public override void InitializeGameMode()
    {

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