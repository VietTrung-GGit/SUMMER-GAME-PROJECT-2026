using UnityEngine;

public abstract class AdBuilder : MonoBehaviour
{
    public abstract void BuildTitleIcon(Ad targetAd);
    public abstract void BuildActionIcon(Ad targetAd);
    public abstract void BuildConfirmAction(Ad targetAd);
}