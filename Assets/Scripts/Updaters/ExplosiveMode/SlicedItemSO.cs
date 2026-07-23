using UnityEngine;

public abstract class SlicedItemSO : ScriptableObject
{
    [SerializeField] protected double itemValue;
    [SerializeField] protected ViewValue viewValue;
    [SerializeField] protected LikeValue likeValue;
    //[SerializeField] private List<CountActionSO> countActions;
    public abstract void ExecuteSlicedAction();
    public abstract void ExecuteOutOfViewAction();

    //public List<CountActionSO> SlicedItemCountActions => countActions;
}