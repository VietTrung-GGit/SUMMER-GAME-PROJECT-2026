using UnityEngine;
[CreateAssetMenu(fileName = "CorrectCloseAd", menuName = "AdButtonActions/CorrectCloseAd")]
public class CorrectCloseAdAction : AdAction
{
    public override void UpdateViewCount(double viewValue)
    {
        GameCountManager.Instance.UpdateViewCount(viewValue);
    }
    public override void UpdateLikeCount(double likeValue)
    {
        GameCountManager.Instance.UpdateLikeCount(likeValue);
    }
}