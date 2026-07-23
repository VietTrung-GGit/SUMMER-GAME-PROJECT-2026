using UnityEngine;
[CreateAssetMenu(fileName = "SlicedHeal", menuName = "SlicedItem/SlicedHeal")]
public class SlicedHeal : SlicedItemSO
{
    public override void ExecuteSlicedAction()
    {
        GameCountManager.Instance.UpdateHealthCount(itemValue);
        GameCountManager.Instance.UpdateViewCount((int)viewValue);
        GameCountManager.Instance.UpdateLikeCount((int)likeValue);
    }

    public override void ExecuteOutOfViewAction()
    {
        GameCountManager.Instance.UpdateViewCount(-(int)viewValue);
        GameCountManager.Instance.UpdateLikeCount(-(int)likeValue);
    }

}