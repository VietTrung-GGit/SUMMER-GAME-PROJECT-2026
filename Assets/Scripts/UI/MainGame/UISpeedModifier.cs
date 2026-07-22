using System;
using TMPro;
using UnityEngine;

public class UISpeedModifier : MonoBehaviour
{
    //[SerializeField] private StatTracker balanceTracker;
    //[SerializeField] private TimeTracker gameTimeTracker;
    [SerializeField] private StatTracker speedModifierTracker;
    //[SerializeField] private TimeTracker speedModTimeTracker;

    //[SerializeField] private GameObject timer;
    [SerializeField] private TMP_Text modifierText;
    //[SerializeField] private Image timerTexture;
    /*private float speedValue = 1.0f;
    private const float SPEED_MULTIPLIER = 2.0f;
    private double maxTime;*/
    /*private void Awake()
    {
        maxTime = speedModTimeTracker.TimeCount;
        //modifierText.text = "x" + Math.Floor(priceModifierTracker.StatCount).ToString();
    }*/
    private void OnEnable()
    {
        speedModifierTracker.OnStatCountChanged += UpdateTextDisplay;
        //speedModTimeTracker.OnTimeCountChanged += UpdateTimerTexture;
        //speedModTimeTracker.OnTimeCountExpired += OnTimerExpired;

        /*if (speedModifierTracker.StatCount >= 1.0f)
        {
            modifierText.text = "x" + Math.Floor(speedModifierTracker.StatCount).ToString();
        }
        else
        {
            modifierText.text = "x" + Math.Round(speedModifierTracker.StatCount,2).ToString();
        }*/
        modifierText.SetText("x" + Math.Round(speedModifierTracker.StatCount,2).ToString());
    }
    private void OnDisable()
    {
        speedModifierTracker.OnStatCountChanged -= UpdateTextDisplay;
        //speedModTimeTracker.OnTimeCountChanged -= UpdateTimerTexture;
        //speedModTimeTracker.OnTimeCountExpired -= OnTimerExpired;
        //timerTexture.fillAmount = 1.0f;
    }

    /*private void UpdateTimerTexture(double amount)
    {
        timerTexture.fillAmount = (float) (amount/maxTime);
    }*/

    private void UpdateTextDisplay(double amount)
    {
        //modifierText.text = "x" + Math.Floor(priceModifierTracker.StatCount).ToString();
        if (Math.Abs(speedModifierTracker.StatCount - 1.0f) < 1e-9)
        {
            gameObject.SetActive(false);
        }
        else
        {
            modifierText.SetText("x" + Math.Round(speedModifierTracker.StatCount,2).ToString());
        }
        /*else if (speedModifierTracker.StatCount >= 1.0f)
        {
            modifierText.text = "x" + Math.Floor(speedModifierTracker.StatCount).ToString();
        }
        else
        {
            modifierText.text = "x" + Math.Round(speedModifierTracker.StatCount,2).ToString();
        }*/
    }
    /*private void OnTimerExpired()
    {
        if (balanceTracker.StatCount >= 0.0f)
        {
            gameObject.SetActive(false);
        }
    }*/
}
