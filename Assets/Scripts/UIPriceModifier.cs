using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPriceModifier : MonoBehaviour
{
    [SerializeField] private StatTracker priceModifierTracker;
    [SerializeField] private TimeTracker priceModTimeTracker;
    //[SerializeField] private GameObject timer;
    [SerializeField] private TMP_Text modifierText;
    [SerializeField] private Image timerTexture;
    private double maxTime;
    private void Awake()
    {
        maxTime = priceModTimeTracker.TimeCount;
        Debug.Log(priceModifierTracker.StatCount);
        //modifierText.text = "x" + Math.Floor(priceModifierTracker.StatCount).ToString();
    }
    private void OnEnable()
    {
        priceModifierTracker.OnStatCountChanged += UpdateTextDisplay;
        priceModTimeTracker.OnTimeCountChanged += UpdateTimerTexture;
        priceModTimeTracker.OnTimeCountExpired += OnTimerExpired;

        if (priceModifierTracker.StatCount >= 1.0f)
        {
            modifierText.text = "x" + Math.Floor(priceModifierTracker.StatCount).ToString();
        }
        else
        {
            modifierText.text = "x" + Math.Round(priceModifierTracker.StatCount,2).ToString();
        }
    }
    private void OnDisable()
    {
        priceModifierTracker.OnStatCountChanged -= UpdateTextDisplay;
        priceModTimeTracker.OnTimeCountChanged -= UpdateTimerTexture;
        priceModTimeTracker.OnTimeCountExpired -= OnTimerExpired;
        timerTexture.fillAmount = 1.0f;
    }
    /*private void Update()
    {
        priceModTimeTracker.TimeCount -= Time.deltaTime;
    }*/

    private void UpdateTimerTexture(double amount)
    {
        timerTexture.fillAmount = (float) (amount/maxTime);
    }

    private void UpdateTextDisplay(double amount)
    {
        //modifierText.text = "x" + Math.Floor(priceModifierTracker.StatCount).ToString();
        Debug.Log(priceModifierTracker.StatCount);
        if (Math.Abs(priceModifierTracker.StatCount - 1.0f) < 1e-9)
        {
            gameObject.SetActive(false);
        }
        else if (priceModifierTracker.StatCount >= 1.0f)
        {
            modifierText.text = "x" + Math.Floor(priceModifierTracker.StatCount).ToString();
        }
        else
        {
            modifierText.text = "x" + Math.Round(priceModifierTracker.StatCount,2).ToString();
        }
    }
    private void OnTimerExpired()
    {
        gameObject.SetActive(false);
    }
}
