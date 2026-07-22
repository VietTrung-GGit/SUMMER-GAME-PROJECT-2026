using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIKeypadExplosive : MonoBehaviour
{
    [SerializeField] private TMP_Text keypadText;
    [SerializeField] private Image explosiveTimerTexture;
    [SerializeField] private TimeTracker explosiveTimeTracker;
    [SerializeField] private KeypadExplosiveUpdater keypadExplosiveUpdater;
    private double maxTime;

    private void Awake()
    {
        maxTime = explosiveTimeTracker.TimeCount;
    }
    private void OnEnable()
    {
        explosiveTimeTracker.OnTimeCountChanged += UpdateTimerTexture;
        keypadExplosiveUpdater.OnNewKeypadSequence += UpdateTextDisplay;
        keypadExplosiveUpdater.OnKeypadSequenceReset += ResetKeypadExplosiveUI;
        //keypadExplosiveUpdater.OnCorrectDigitInput += UpdateDigitDisplay;
    }

    private void OnDisable()
    {
        explosiveTimeTracker.OnTimeCountChanged -= UpdateTimerTexture;
        keypadExplosiveUpdater.OnNewKeypadSequence -= UpdateTextDisplay;
        keypadExplosiveUpdater.OnKeypadSequenceReset -= ResetKeypadExplosiveUI;
        //keypadExplosiveUpdater.OnCorrectDigitInput -= UpdateDigitDisplay;
    }

    private void UpdateTimerTexture(double amount)
    {
        explosiveTimerTexture.fillAmount = (float) (amount/maxTime);
    }

    private void UpdateTextDisplay(int number)
    {
        keypadText.SetText(number.ToString());
    }

    private void UpdateDigitDisplay(int index)
    {
        //Example
        string newTextDisplay = keypadText.text;
        newTextDisplay = newTextDisplay.Insert(index + 1, "</color>");
        newTextDisplay = newTextDisplay.Insert(index, "<color=red>");
        keypadText.SetText(newTextDisplay);
    }

    private void ResetKeypadExplosiveUI()
    {
        explosiveTimerTexture.fillAmount = 1.0f;
        keypadText.SetText("----");
    }

}