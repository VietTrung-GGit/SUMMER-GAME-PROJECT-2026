using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private float timeMax = 30.0f;
    private float timeRemaining;
    [SerializeField] private Slider timerSlider;
    private void Awake()
    {
        timeRemaining = timeMax;
        timerSlider.value = timeMax;
    }
    private void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (timerSlider)
        {
            timerSlider.value = timeRemaining;
        }
        
        if (timeRemaining <= 0.0f)
        {
            OnTimerExpire();
        }
    }

    private void OnTimerExpire()
    {
        Time.timeScale = 0.0f;
    }
}
