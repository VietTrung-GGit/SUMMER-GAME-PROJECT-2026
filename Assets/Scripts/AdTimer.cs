using UnityEngine;
using UnityEngine.UI;

public class AdTimer : MonoBehaviour
{
    [SerializeField] private float timeMax = 5.0f;
    private float timeRemaining;
    [SerializeField] private Slider timerSlider;
    private void Awake()
    {
        timeRemaining = timeMax;
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
