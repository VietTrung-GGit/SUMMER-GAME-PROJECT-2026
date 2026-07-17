
public abstract class AdExecuteAction : AdAction
{
    /*[SerializeField] protected StatTracker viewTracker;
    [SerializeField] protected StatTracker likeTracker;
    [SerializeField] private PerformanceUpdater viewUpdater;
    [SerializeField] private PerformanceUpdater likeUpdater;*/
    public abstract void ExecuteAction(double amount);
    /*public abstract void UpdateViewCount(ViewValue viewValue);
    public abstract void UpdateLikeCount(LikeValue likeValue);*/
}