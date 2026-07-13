using System;
using UnityEngine;

[CreateAssetMenu]
public class BalanceTracker : ScriptableObject
{
    [SerializeField] private double balance;
    public double Balance
    {
        get => balance;
        set
        {
            balance = value;
            OnBalanceChanged?.Invoke(balance);
        }
    }

    public event Action<double> OnBalanceChanged;

    private void OnEnable()
    {
        balance = 1000000;
    }

}