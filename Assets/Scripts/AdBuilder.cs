using UnityEngine;

public abstract class AdBuilder : MonoBehaviour
{
    public abstract void Randomize();
    public abstract void BuildAdTimer(Ad targetAd);
    public abstract void BuildIcon(Ad targetAd);
    //public abstract void BuildActionIcon(Ad targetAd);
    public abstract void BuildAdButtonActions(Ad targetAd);
}