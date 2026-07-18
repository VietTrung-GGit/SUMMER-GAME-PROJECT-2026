using UnityEngine;
[CreateAssetMenu(fileName = "DecreaseHealth", menuName = "AdButtonActions/DecreaseHealth")]
public class DecreaseHealthAction : AdExecuteAction
{
    public override void ExecuteAction(double amount)
    {
        BaseGameCountManager.Instance.UpdateHealthCount(-amount);
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