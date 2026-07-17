using System;
using UnityEngine;
using UnityEngine.UI;

public class AdTimer : MonoBehaviour
{
    [SerializeField] private Slider timerSlider;
    private Action<double> timerExpiredAction = null;
    private double actionParam;
    private float timeMax = 1.0f;
    private float timeRemaining;
    public void SetMaxTime(float amount)
    {
        timeMax = amount;
        timeRemaining = timeMax;
        timerSlider.value = timeMax;
    }
    /*private void Awake()
    {
        timeRemaining = timeMax;
        timerSlider.value = timeMax;
    }*/
    public void SetTimerExpiredAction(Action<double> action, double amount)
    {
        timerExpiredAction = action;
        actionParam = amount;
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
        if (timerExpiredAction != null)
        {
            timerExpiredAction?.Invoke(actionParam);
        }
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        timeRemaining = timeMax;
        timerSlider.value = timeMax;
    }
}
