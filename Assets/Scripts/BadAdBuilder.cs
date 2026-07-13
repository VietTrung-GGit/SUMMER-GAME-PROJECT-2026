using UnityEngine;

public class BadAdBuilder : AdBuilder
{
    [SerializeField] private Sprite newIcon;
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
        throw new System.NotImplementedException();
    }
}