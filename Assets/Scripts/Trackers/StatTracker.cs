using System;
using UnityEngine;

[CreateAssetMenu(fileName = "StatTracker", menuName = "Trackers/StatTracker")]
public class StatTracker : ScriptableObject
{
    [SerializeField] private double statCount;
    [SerializeField] private double startStatCount;
    [SerializeField] private double maxStatCount;
    [SerializeField] private double minStatCount;
    public double StatCount
    {
        get => statCount;
        set
        {
            if (value >= maxStatCount)
            {
                statCount = maxStatCount;
            }
            else if (value <= minStatCount)
            {
                statCount = minStatCount;
            }
            else
            {
                statCount = value;
            }
            OnStatCountChanged?.Invoke(statCount);

            if (statCount < 0.0f)
            {
                OnNegativeStatCount?.Invoke();
            }
        }
    }

    public event Action<double> OnStatCountChanged;
    public event Action OnNegativeStatCount;

    private void OnEnable()
    {
        statCount = startStatCount;
    }

    private void OnValidate()
    {
        statCount = startStatCount;
    }

}