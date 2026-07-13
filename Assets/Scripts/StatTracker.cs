using System;
using UnityEngine;

[CreateAssetMenu]
public class StatTracker : ScriptableObject
{
    [SerializeField] private double statCount;
    public double StatCount
    {
        get => statCount;
        set
        {
            statCount = value;
            OnStatCountChanged?.Invoke(statCount);
        }
    }

    public event Action<double> OnStatCountChanged;

    private void OnEnable()
    {
        statCount = 0;
    }

}