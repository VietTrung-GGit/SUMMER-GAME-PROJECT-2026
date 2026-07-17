using UnityEngine;

public class SpeedModifierUpdater : MonoBehaviour
{
    //[SerializeField] private StatTracker balanceTracker;
    [SerializeField] private TimeTracker gameTimeTracker;
    [SerializeField] private StatTracker speedModifierTracker;
    //[SerializeField] private TimeTracker speedModTimeTracker;
    [SerializeField] private GameObject speedModifier;
    private const double SPEED_INCREMENT = 0.25f;
    //private const double REGULAR_MODIFIER = 1.0f;
    private void OnEnable()
    {
        //balanceTracker.OnNegativeStatCount += OnOverlimit;
        //speedModTimeTracker.OnTimeCountExpired += OnTimerExpired;
        gameTimeTracker.OnTimeCountExpired += OnGameTimerExpired;
    }

    private void OnDisable()
    {
        //balanceTracker.OnNegativeStatCount -= OnOverlimit;
        //speedModTimeTracker.OnTimeCountExpired -= OnTimerExpired;
        gameTimeTracker.OnTimeCountExpired -= OnGameTimerExpired;
    }

    /*private void Update()
    {
        if (!speedModifier.activeSelf)
        {
            return;
        }
        speedModTimeTracker.TimeCount -= Time.deltaTime;
    }*/
    /*private void OnOverlimit()
    {
        //Could this be decoupled?
        //Math.Abs(speedModifierTracker.StatCount - 1.0f) > 1e-9
        //speedModTimeTracker.ResetTimer();
        if (!speedModifier.activeSelf)
        {
            speedModifier.SetActive(true);
            speedModifierTracker.StatCount += SPEED_INCREMENT;
        }
    }

    private void OnTimerExpired()
    {
        if (balanceTracker.StatCount < 0.0f)
        {
            speedModifierTracker.StatCount += SPEED_INCREMENT;
        }
        else
        {
            speedModifierTracker.StatCount = REGULAR_MODIFIER;
        }
        speedModTimeTracker.ResetTimer();
    }*/
    private void OnGameTimerExpired()
    {
        if (!speedModifier.activeSelf)
        {
            speedModifier.SetActive(true);
        }
        speedModifierTracker.StatCount += SPEED_INCREMENT;
        if (!speedModifier.activeSelf)
        {
            return;
        }
    }
}