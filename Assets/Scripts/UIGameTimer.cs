using UnityEngine;
using UnityEngine.UI;

public class UIGameTimer : MonoBehaviour
{
    [SerializeField] private TimeTracker gameTimeTracker;
    [SerializeField] private Slider timerSlider;
    private void Awake()
    {
        timerSlider.value = (float)gameTimeTracker.TimeCount;
    }

    private void OnEnable()
    {
        gameTimeTracker.OnTimeCountChanged += UpdateTimeSlider;
        gameTimeTracker.OnTimeCountExpired += OnTimerExpire;
    }
    private void OnDisable()
    {
        gameTimeTracker.OnTimeCountChanged -= UpdateTimeSlider;
        gameTimeTracker.OnTimeCountExpired -= OnTimerExpire;
    }

    private void UpdateTimeSlider(double amount)
    {
        timerSlider.value = (float)amount;
    }
    private void OnTimerExpire()
    {
        timerSlider.value = 0.0f;
    }
}
