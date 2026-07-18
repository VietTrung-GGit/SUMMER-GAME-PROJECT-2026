using System.Collections.Generic;
using UnityEngine;

public class GameModeManager : MonoBehaviour
{
    //May consider lazy initialization for this Singleton
    private Dictionary<GameModeSO, bool> activeGameModeDict = new Dictionary<GameModeSO, bool>();
    private readonly List<GameModeRuntime> activeGameModeInstances = new List<GameModeRuntime>();
    public static GameModeManager Instance {get; private set;}

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ToggleGameMode(GameModeSO gameModeSO, bool isEnabled)
    {
        if (activeGameModeDict.ContainsKey(gameModeSO))
        {
            activeGameModeDict[gameModeSO] = isEnabled;
        }
        else
        {
            activeGameModeDict.Add(gameModeSO, isEnabled);
        }
    }

    public void ActivateGameModes()
    {
        foreach (GameModeSO gameModeSO in activeGameModeDict.Keys)
        {
            if (activeGameModeDict[gameModeSO])
            {
                GameModeRuntime gameModeInstance = Instantiate(gameModeSO.GameModePrefab);
                activeGameModeInstances.Add(gameModeInstance);
                gameModeInstance.InitializeGameMode();
            }
        }
    }

    public void DeactivateGameModes()
    {
        foreach (GameModeRuntime gameModeInstance in activeGameModeInstances)
        {
            gameModeInstance.DestroyGameMode();
        }
        activeGameModeInstances.Clear();
    }
}