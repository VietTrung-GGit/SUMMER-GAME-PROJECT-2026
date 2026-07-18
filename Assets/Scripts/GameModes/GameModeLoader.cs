using UnityEngine;
class GameModeLoader : MonoBehaviour
{
    private void Start()
    {
        if (GameModeManager.Instance)
        {
            GameModeManager.Instance.ActivateGameModes();
        }
    }
}