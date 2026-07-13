using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class BalanceCount : MonoBehaviour
{
    [SerializeField] private float intervalMax;
    [SerializeField] private float animationSpeed = 5.0f;
    [SerializeField] private double fixedIncrement = 1;
    [SerializeField] private double currentCount = 1000000;
    private TMP_Text balanceText;
    private float intervalRemaining;
    private double targetCount = 1000000;
    //Prevent garbage strings
    private string lastDisplayedString = "";
    private const double BALANCE_MAX_VALUE = 999999999;
    private void Awake()
    {
        intervalRemaining = intervalMax;
        balanceText = GetComponent<TMP_Text>();

    }
    private void Update()
    {
        intervalRemaining -= Time.deltaTime;
        if (intervalRemaining <= 0.0f)
        {
            UpdateBalanceCount(fixedIncrement);
            intervalRemaining = intervalMax;
        }

        if (Math.Abs(targetCount - currentCount) > 0.05f)
        {
            currentCount += (targetCount - currentCount)*animationSpeed*Time.deltaTime;
            UpdateTextDisplay();
        }
        else if (!Double.Equals(currentCount, targetCount))
        {
            currentCount = targetCount;
            UpdateTextDisplay();
        }
    }
    public void UpdateBalanceCount(double increment)
    {
        targetCount = currentCount + increment;
        if (targetCount > BALANCE_MAX_VALUE)
        {
            targetCount = BALANCE_MAX_VALUE;
        }
    }

    private void UpdateTextDisplay()
    {
        string formattedText = FormatNumber(currentCount);
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
