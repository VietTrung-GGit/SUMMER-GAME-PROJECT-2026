using System;
using System.Numerics;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class StatCount : MonoBehaviour
{
    [SerializeField] private float intervalMax;
    [SerializeField] private float animationSpeed = 5.0f;
    [SerializeField] private double fixedIncrement = 1;
    private TMP_Text statText;
    private float intervalRemaining;
    private double currentCount = 0;
    private double targetCount = 0;
    //Prevent garbage strings
    private string lastDisplayedString = "";
    private const string VALUE_MAX_STRING = "MAX";
    private const double STAT_MAX_VALUE = 999999999999;
    private void Awake()
    {
        intervalRemaining = intervalMax;
        statText = GetComponent<TMP_Text>();

    }
    private void Update()
    {
        intervalRemaining -= Time.deltaTime;
        if (intervalRemaining <= 0.0f)
        {
            UpdateStatCount(fixedIncrement);
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

    public void UpdateStatCount(double increment)
    {
        targetCount = currentCount + increment;
        if (targetCount > STAT_MAX_VALUE)
        {
            targetCount = STAT_MAX_VALUE;
        }
    }

    private void UpdateTextDisplay()
    {
        string formattedText = FormatNumber(currentCount);
        if (!String.Equals(formattedText, lastDisplayedString))
        {
            statText.text = formattedText;
            lastDisplayedString = formattedText;
        }
    }

    private string FormatNumber(double number)
    {
        double displayNumber = Math.Floor(number);
        if (displayNumber < 1000)
        {
            return displayNumber.ToString("N0");
        }

        if (displayNumber < 1000000)
        {
            return (displayNumber/1000.0).ToString("0.#") + "K";
        }

        if (displayNumber < 1000000000)
        {
            return (displayNumber/1000000).ToString("0.#") + "M";
        }

        if (displayNumber < 1000000000000)
        {
            return (displayNumber/1000000000).ToString("0.#") + "B";
        }

        return VALUE_MAX_STRING;
    }

}
