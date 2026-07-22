using UnityEngine;
[CreateAssetMenu(fileName = "CorrectCloseAd", menuName = "AdActions/CorrectCloseAd")]
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