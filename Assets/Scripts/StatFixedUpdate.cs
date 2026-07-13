using System;
using UnityEngine;

public class StatFixedUpdate : MonoBehaviour
{
    [SerializeField] private float intervalMax;
    [SerializeField] private float animationSpeed = 5.0f;
    [SerializeField] private double fixedIncrement = 1;
    [SerializeField] private StatTracker statTracker;
    private float intervalRemaining;
    private double targetCount = 0;
    private const double STAT_MAX_VALUE = 999999999999;
    private void Awake()
    {
        intervalRemaining = intervalMax;

    }
    private void Update()
    {
        intervalRemaining -= Time.deltaTime;
        if (intervalRemaining <= 0.0f)
        {
            UpdateStatCount(fixedIncrement);
            intervalRemaining = intervalMax;
        }

        if (Math.Abs(targetCount - statTracker.StatCount) > 0.05f)
        {
            statTracker.StatCount += (targetCount - statTracker.StatCount)*animationSpeed*Time.deltaTime;
        }
        else if (!Double.Equals(statTracker.StatCount, targetCount))
        {
            statTracker.StatCount = targetCount;
        }
    }

    public void UpdateStatCount(double increment)
    {
        targetCount = statTracker.StatCount + increment;
        if (targetCount > STAT_MAX_VALUE)
        {
            targetCount = STAT_MAX_VALUE;
        }
    }

}