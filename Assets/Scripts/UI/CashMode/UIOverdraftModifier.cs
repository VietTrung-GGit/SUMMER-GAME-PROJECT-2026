using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIOverdraftModifier : MonoBehaviour
{
    [SerializeField] private StatTracker overdraftModifierTracker;
    [SerializeField] private TimeTracker overdraftModTimeTracker;
    [SerializeField] private TMP_Text modifierText;
    [SerializeField] private Image timerTexture;
    private double maxTime;
    private void Awake()
    {
        maxTime = overdraftModTimeTracker.TimeCount;
    }
    private void OnEnable()
    {
        overdraftModifierTracker.OnStatCountChanged += UpdateTextDisplay;
        overdraftModTimeTracker.OnTimeCountChanged += UpdateTimerTexture;
        modifierText.SetText("x" + Math.Floor(overdraftModifierTracker.StatCount).ToString());
    }
    private void OnDisable()
    {
        overdraftModifierTracker.OnStatCountChanged -= UpdateTextDisplay;
        overdraftModTimeTracker.OnTimeCountChanged -= UpdateTimerTexture;
        timerTexture.fillAmount = 1.0f;
    }

    private void UpdateTimerTexture(double amount)
    {
        timerTexture.fillAmount = (float) (amount/maxTime);
    }

    private void UpdateTextDisplay(double amount)
    {
        modifierText.SetText("x" + Math.Floor(amount).ToString());
    }
}
