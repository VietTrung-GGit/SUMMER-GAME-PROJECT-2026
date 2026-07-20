using System;
using UnityEngine;

public class BlindTimer : MonoBehaviour
{
    [SerializeField] private float maxTime;
    public Action OnBlindTimerExpired;
}