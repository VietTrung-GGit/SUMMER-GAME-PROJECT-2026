using UnityEngine;

[CreateAssetMenu(fileName = "New GameMode", menuName = "CustomGame/GameMode")]
public class GameModeSO : ScriptableObject
{
    [SerializeField] private string gameModeName;
    [TextArea] public string gameModeDescription;
    //[SerializeField] private UITargetZone targetZone;
    [SerializeField] private Sprite icon;
    [SerializeField] private GameModeRuntime gameModePrefab;
    public GameModeRuntime GameModePrefab => gameModePrefab;
}