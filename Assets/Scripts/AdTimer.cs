using UnityEngine;
using UnityEngine.UI;

public class AdTimer : MonoBehaviour
{
    [SerializeField] private float timeMax = 5.0f;
    [SerializeField] private Slider timerSlider;
    private float timeRemaining;
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
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        timeRemaining = timeMax;
    }
}
