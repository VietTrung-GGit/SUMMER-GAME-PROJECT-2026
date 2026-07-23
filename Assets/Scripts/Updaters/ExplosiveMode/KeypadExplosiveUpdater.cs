using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class KeypadExplosiveUpdater : MonoBehaviour
{
    [SerializeField] private TimeTracker explosiveTimeTracker;
    //[SerializeField] private TimeTracker newSequenceTimeTracker;
    [SerializeField] private StatTracker speedModifierTracker;
    [SerializeField] private double penaltyDamage;
    [SerializeField] private double failureDamage;
    [SerializeField] private float baseMaxSequenceInterval = 15.0f;
    private float newSequenceTimeRemaining;
    private float currentMaxSequenceInterval;
    //private Key[] keypadNumberKeys = new Key[10];
    private int currentIndex = 0;
    private readonly Key[] targetKeypadSequence = new Key[4];
    public Action<int> OnNewKeypadSequence;
    public Action OnKeypadSequenceReset;
    public Action<int> OnCorrectDigitInput;
    private bool isDetectingInput = true;
    //private int targetNumberSequence;

    private void OnEnable()
    {
        //newSequenceTimeTracker.OnTimeCountExpired += GenerateNewKeypadSequence;
        explosiveTimeTracker.OnTimeCountExpired += OnFailedToDefuse;
        speedModifierTracker.OnStatCountChanged += OnSpeedModifierChanged;

    }

    private void OnDisable()
    {
        //newSequenceTimeTracker.OnTimeCountExpired -= GenerateNewKeypadSequence;
        explosiveTimeTracker.OnTimeCountExpired -= OnFailedToDefuse;
        speedModifierTracker.OnStatCountChanged -= OnSpeedModifierChanged;
    }

    private void Awake()
    {
        currentMaxSequenceInterval = baseMaxSequenceInterval;
        newSequenceTimeRemaining = currentMaxSequenceInterval;
    }

    private void Start()
    {
        GenerateNewKeypadSequence();
    }

    private void Update()
    {
        if (!isDetectingInput)
        {
            //newSequenceTimeTracker.TimeCount -= Time.deltaTime;
            newSequenceTimeRemaining -= Time.deltaTime;
            if (newSequenceTimeRemaining <= 0.0f)
            {
                GenerateNewKeypadSequence();
            }
        }
        else
        {
            explosiveTimeTracker.TimeCount -= Time.deltaTime;
        }

        if (isDetectingInput && Keyboard.current.anyKey.wasPressedThisFrame)
        {
            DetectPressedKey();
        }
    }

    private void DetectPressedKey()
    {
        foreach (KeyControl key in Keyboard.current.allKeys)
        {
            if (key.wasPressedThisFrame)
            {
                ProcessKeyInput(key);
                break;
            }
        }
    }

    private void ProcessKeyInput(KeyControl key)
    {
        if (key.keyCode == targetKeypadSequence[currentIndex])
        {
            OnCorrectDigitInput?.Invoke(currentIndex);
            currentIndex++;
            if (currentIndex >= targetKeypadSequence.Length)
            {
                ResetKeypadSequence();
                OnKeypadSequenceReset?.Invoke();
            }
        }
        else
        {
            GameCountManager.Instance.UpdateHealthCount(-penaltyDamage);
        }
    }

    private void GenerateNewKeypadSequence()
    {
        int targetNumberSequence = UnityEngine.Random.Range(1000, 10000);
        OnNewKeypadSequence?.Invoke(targetNumberSequence);
        int index = 3;
        while (index >= 0)
        {
            targetKeypadSequence[index] = Key.Numpad0 + targetNumberSequence % 10;
            targetNumberSequence /= 10;
            index--;
        }
        isDetectingInput = true;
    }

    private void OnFailedToDefuse()
    {
        GameCountManager.Instance.UpdateHealthCount(-failureDamage);
        ResetKeypadSequence();
        OnKeypadSequenceReset?.Invoke();
    }

    private void ResetKeypadSequence()
    {
        isDetectingInput = false;
        //newSequenceTimeTracker.ResetTimer();
        newSequenceTimeRemaining = currentMaxSequenceInterval;
        explosiveTimeTracker.ResetTimer();
        currentIndex = 0;
    }

    private void OnSpeedModifierChanged(double amount)
    {
        currentMaxSequenceInterval = baseMaxSequenceInterval/(float)speedModifierTracker.StatCount;
    }
}