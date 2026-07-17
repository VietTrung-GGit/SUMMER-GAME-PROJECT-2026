using UnityEngine;
[CreateAssetMenu(fileName = "DecreaseHealth", menuName = "AdButtonActions/DecreaseHealth")]
public class DecreaseHealthAction : AdExecuteAction
{
    public override void ExecuteAction(double amount)
    {
        GameCountManager.Instance.UpdateHealthCount(-amount);
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