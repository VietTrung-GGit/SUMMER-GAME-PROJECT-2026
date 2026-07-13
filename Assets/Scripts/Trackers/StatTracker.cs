using System;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class StatTracker : ScriptableObject
{
    [SerializeField] private double statCount;
    [SerializeField] private double startStatCount;
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
        statCount = startStatCount;
    }

    private void OnValidate()
    {
        statCount = startStatCount;
    }

}