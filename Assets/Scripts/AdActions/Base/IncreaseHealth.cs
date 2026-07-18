using UnityEngine;
[CreateAssetMenu(fileName = "IncreaseHealth", menuName = "AdButtonActions/IncreaseHealth")]
public class IncreaseHealthAction : AdExecuteAction
{
    public override void ExecuteAction(double amount)
    {
        BaseGameCountManager.Instance.UpdateHealthCount(amount);
    }
    public override void UpdateViewCount(double viewValue)
    {
        BaseGameCountManager.Instance.UpdateViewCount(viewValue);
    }

    public override void UpdateLikeCount(double likeValue)
    {
        BaseGameCountManager.Instance.UpdateLikeCount(likeValue);
    }
}