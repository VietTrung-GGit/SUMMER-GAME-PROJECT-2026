using UnityEngine;

public class CashModeCountManager : MonoBehaviour
{
    [SerializeField] private BalanceUpdater balanceUpdater;
    public static CashModeCountManager Instance {get; private set;}
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void UpdateBalanceCount(double amount)
    {
        //Debug.Log("Update balance called!" + amount);
        balanceUpdater.UpdateBalanceCount(amount);
    }

}