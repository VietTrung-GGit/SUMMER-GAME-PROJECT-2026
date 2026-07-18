using UnityEngine;
[CreateAssetMenu(fileName = "WrongCloseAd", menuName = "AdButtonActions/WrongCloseAd")]
public class WrongCloseAdAction : AdAction
{
    public override void UpdateViewCount(double viewValue)
    {
        BaseGameCountManager.Instance.UpdateViewCount(-viewValue);
    }
    public override void UpdateLikeCount(double likeValue)
    {
        BaseGameCountManager.Instance.UpdateLikeCount(-likeValue);
    }
}