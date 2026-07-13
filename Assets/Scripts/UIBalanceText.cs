using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TMP_Text))]
public class UIBalanceText : MonoBehaviour
{
    [SerializeField] private BalanceTracker balanceTracker;
    private TMP_Text balanceText;
    //Prevent garbage strings
    private string lastDisplayedString = "";

    private void Awake()
    {
        balanceText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        balanceTracker.OnBalanceChanged += UpdateTextDisplay;
    }

    private void OnDisable()
    {
        balanceTracker.OnBalanceChanged -= UpdateTextDisplay;
    }

    private void UpdateTextDisplay(double count)
    {
        string formattedText = FormatNumber(count);
        if (!String.Equals(formattedText, lastDisplayedString))
        {
            balanceText.text = formattedText;
            lastDisplayedString = formattedText;
        }
    }

    private string FormatNumber(double number)
    {
        double displayNumber = Math.Floor(number);
        return "$ " + displayNumber.ToString("N0");
    }
}