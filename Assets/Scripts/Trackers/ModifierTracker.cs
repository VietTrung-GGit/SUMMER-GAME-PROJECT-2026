using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ModifierTracker", menuName = "Trackers/ModifierTracker")]
public class ModifierTracker : ScriptableObject
{
    [SerializeField] private double modifierValue;
    [SerializeField] private double startModifierValue;
    public double ModifierValue
    {
        get => modifierValue;
        set
        {
            modifierValue = value;
            OnModifierValueChanged?.Invoke(modifierValue);
        }
    }

    public event Action<double> OnModifierValueChanged;

    private void OnEnable()
    {
        modifierValue = startModifierValue;
    }

    private void OnValidate()
    {
        modifierValue = startModifierValue;
    }

}