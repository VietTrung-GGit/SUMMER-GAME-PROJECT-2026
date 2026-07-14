using UnityEngine;

public abstract class ConfirmAction : ScriptableObject
{
    [SerializeField] protected StatTracker viewTracker;
    [SerializeField] protected StatTracker likeTracker;
    public abstract void ExecuteAction(double amount);
    public void UpdateViewCount(ViewValue viewValue)
    {
        viewTracker.StatCount += (int)viewValue;
    }
    public void UpdateLikeCount(LikeValue likeValue)
    {
        likeTracker.StatCount += (int)likeValue;
    }
}