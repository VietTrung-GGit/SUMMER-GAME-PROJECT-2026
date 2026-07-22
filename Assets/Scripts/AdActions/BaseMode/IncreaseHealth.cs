using UnityEngine;
[CreateAssetMenu(fileName = "IncreaseHealth", menuName = "AdActions/IncreaseHealth")]
public class IncreaseHealthAction : AdExecuteAction
{
    public override void ExecuteAction(double amount)
    {
        GameCountManager.Instance.UpdateHealthCount(amount);
    }
    public override void UpdateViewCount(double viewValue)
    {
        GameCountManager.Instance.UpdateViewCount(viewValue);
    }

    public override void UpdateLikeCount(double likeValue)
    {
        GameCountManager.Instance.UpdateLikeCount(likeValue);
    }
}