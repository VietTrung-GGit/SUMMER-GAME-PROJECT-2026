using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TMP_Text))]
public class UIPerformanceText : MonoBehaviour
{
    [SerializeField] private StatTracker performanceTracker;
    private TMP_Text statCountText;
    //Prevent garbage strings
    private string lastDisplayedString = "";
    private const string VALUE_MAX_STRING = "MAX";

    private void Awake()
    {
        statCountText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        performanceTracker.OnStatCountChanged += UpdateTextDisplay;
    }

    private void OnDisable()
    {
        performanceTracker.OnStatCountChanged -= UpdateTextDisplay;
    }

    private void UpdateTextDisplay(double count)
    {
        string formattedText = FormatNumber(count);
        if (!String.Equals(formattedText, lastDisplayedString))
        {
            statCountText.text = formattedText;
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