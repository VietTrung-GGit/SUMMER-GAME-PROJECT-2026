using System;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "StatTracker", menuName = "Trackers/StatTracker")]
public class StatTracker : ScriptableObject
{
    [SerializeField] private double statCount;
    [SerializeField] private double startStatCount;
    [SerializeField] private double maxStatCount;
    public double StatCount
    {
        get => statCount;
        set
        {
            if (value >= maxStatCount)
            {
                statCount = maxStatCount;
            }
            else
            {
                statCount = value;
            }
            OnStatCountChanged?.Invoke(statCount);
        }
    }

    public event Action<double> OnStatCountChanged;

    private void OnEnable()
    {
        statCount = startStatCount;
    }

    private void OnValidate()
    {
        statCount = startStatCount;
    }

}