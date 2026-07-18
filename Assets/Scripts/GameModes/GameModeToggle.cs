using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class GameModeToggle : MonoBehaviour
{
    [SerializeField] private GameModeSO gameModeSO;
    private Toggle gameModeToggle;
    private void Awake()
    {
        gameModeToggle = GetComponent<Toggle>();
    }
    private void OnEnable()
    {
        gameModeToggle.onValueChanged.AddListener(OnGameModeToggled);
    }

    private void OnDisable()
    {
        gameModeToggle.onValueChanged.RemoveListener(OnGameModeToggled);
    }

    private void OnGameModeToggled(bool isEnabled)
    {
        GameModeManager.Instance.ToggleGameMode(gameModeSO, isEnabled);
    }
}