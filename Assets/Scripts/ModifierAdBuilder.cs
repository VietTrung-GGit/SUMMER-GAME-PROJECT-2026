using UnityEngine;

public class ModifierAdBuilder : MonoBehaviour, IAdBuilder
{
    [SerializeField] private Sprite newIcon;
    public void BuildTitleIcon(Ad targetAd)
    {
        targetAd.SetTitleIcon(newIcon);
    }

    public void BuildActionIcon(Ad targetAd)
    {
        targetAd.SetActionIcon(newIcon);
    }
}