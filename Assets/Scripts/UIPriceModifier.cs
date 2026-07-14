using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIPriceModifier : MonoBehaviour
{
    [SerializeField] private StatTracker priceModifierTracker;
    [SerializeField] private TimeTracker priceModTimeTracker;
    [SerializeField] private GameObject timer;
    [SerializeField] private TMP_Text modifierText;
    private double maxTime;
    private Image timerTexture;
    private void Awake()
    {
        timerTexture = GetComponent<Image>();
        maxTime = priceModTimeTracker.TimeCount;
        modifierText.text = "x" + Math.Floor(priceModifierTracker.StatCount).ToString();
    }

    private void OnEnable()
    {
        priceModifierTracker.OnStatCountChanged += UpdateTextDisplay;
        priceModTimeTracker.OnTimeCountChanged += UpdateTimerTexture;
        priceModTimeTracker.OnTimeCountExpired += OnTimerExpired;
    }
    private void OnDisable()
    {
        priceModifierTracker.OnStatCountChanged -= UpdateTextDisplay;
        priceModTimeTracker.OnTimeCountChanged -= UpdateTimerTexture;
        priceModTimeTracker.OnTimeCountExpired -= OnTimerExpired;
    }
    private void Update()
    {
        priceModTimeTracker.TimeCount -= Time.deltaTime;
    }

    private void UpdateTimerTexture(double amount)
    {
        timerTexture.fillAmount = (float) (amount/maxTime);
    }

    private void UpdateTextDisplay(double amount)
    {
        modifierText.text = "x" + Math.Floor(priceModifierTracker.StatCount).ToString();
    }
    private void OnTimerExpired()
    {
        timer.SetActive(false);
        timerTexture.fillAmount = 1.0f;
        
    }
}
