using UnityEngine;

public abstract class AdAction : ScriptableObject
{
    public abstract void UpdateViewCount(double viewValue);
    public abstract void UpdateLikeCount(double likeValue);
}