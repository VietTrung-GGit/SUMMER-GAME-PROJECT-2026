using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    [SerializeField] private StatTracker healthTracker;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Image healthTexture;
    private double maxHealth;
    private void Awake()
    {
        maxHealth = healthTracker.StatCount;
    }
    private void OnEnable()
    {
        healthTracker.OnStatCountChanged += UpdateTextDisplay;
        healthTracker.OnStatCountChanged += UpdateHealthTexture;
        healthText.text = Math.Floor(healthTracker.StatCount).ToString();
    }
    private void OnDisable()
    {
        healthTracker.OnStatCountChanged -= UpdateTextDisplay;
        healthTracker.OnStatCountChanged -= UpdateHealthTexture;
        healthTexture.fillAmount = 1.0f;
    }

    private void UpdateHealthTexture(double amount)
    {
        healthTexture.fillAmount = (float) (amount/maxHealth);
    }

    private void UpdateTextDisplay(double amount)
    {
        healthText.text = Math.Floor(amount).ToString();
    }
}
