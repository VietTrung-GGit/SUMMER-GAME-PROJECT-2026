using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private StatTracker gameTimeTracker;
    [SerializeField] private Slider timerSlider;
    private void Awake()
    {
        timerSlider.value = (float)gameTimeTracker.StatCount;
    }

    private void OnEnable()
    {
        gameTimeTracker.OnStatCountChanged += UpdateTimeSlider;
    }
    private void OnDisable()
    {
        gameTimeTracker.OnStatCountChanged -= UpdateTimeSlider;
    }
    private void Update()
    {
        gameTimeTracker.StatCount -= Time.deltaTime;
        
        if (gameTimeTracker.StatCount <= 0.0f)
        {
            OnTimerExpire();
        }
    }

    private void UpdateTimeSlider(double amount)
    {
        timerSlider.value = (float)amount;
    }
    private void OnTimerExpire()
    {
        Time.timeScale = 0.0f;
    }
}
