using System.Collections.Generic;
using UnityEngine;

//Add this to every new level
public class GameModeLevelSet : MonoBehaviour
{
    [SerializeField] private List<GameModeSO> gameModeSOSet;

    public void EnableGameModeSOSet()
    {
        foreach (GameModeSO gameModeSO in gameModeSOSet)
        {
            GameModeManager.Instance.ToggleGameMode(gameModeSO, true);
        }
    }
}