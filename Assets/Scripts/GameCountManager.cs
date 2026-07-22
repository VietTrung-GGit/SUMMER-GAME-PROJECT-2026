using UnityEngine;

public class GameCountManager : MonoBehaviour
{
    [SerializeField] private PerformanceUpdater viewUpdater;
    [SerializeField] private PerformanceUpdater likeUpdater;
    [SerializeField] private GameTimeUpdater gameTimeUpdater;
    //[SerializeField] private BalanceUpdater balanceUpdater;
    [SerializeField] private HealthUpdater healthUpdater;
    public static GameCountManager Instance {get; private set;}
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

    public void UpdateViewCount(double amount)
    {
        //Debug.Log("Update view called!" + amount);
        viewUpdater.UpdateStatCount(amount);
    }

    public void UpdateLikeCount(double amount)
    {
        //Debug.Log("Update Like called!" + amount);
        likeUpdater.UpdateStatCount(amount);
    }

    public void UpdateGameTimeCount(double amount)
    {
        //Debug.Log("Update game time called!" + amount);
        gameTimeUpdater.UpdateGameTime(amount);
    }

    /*public void UpdateBalanceCount(double amount)
    {
        //Debug.Log("Update balance called!" + amount);
        balanceUpdater.UpdateBalanceCount(amount);
    }*/

    public void UpdateHealthCount(double amount)
    {
        healthUpdater.UpdateHealth(amount);
    }
}