using UnityEngine;
[CreateAssetMenu(fileName = "CorrectCloseAd", menuName = "AdButtonActions/CorrectCloseAd")]
public class CorrectCloseAdAction : AdAction
{
    public override void UpdateViewCount(double viewValue)
    {
        BaseGameCountManager.Instance.UpdateViewCount(viewValue);
    }
    public override void UpdateLikeCount(double likeValue)
    {
        BaseGameCountManager.Instance.UpdateLikeCount(likeValue);
    }
}