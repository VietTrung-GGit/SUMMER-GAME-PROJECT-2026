using UnityEngine;
public class GameModeLoader : MonoBehaviour
{
    [SerializeField] private CanvasZoneRegistry canvasZoneRegistry;
    [SerializeField] private AdBuilder adBuilder;
    public static GameModeLoader Instance {get; private set;}
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
    private void Start()
    {
        if (GameModeManager.Instance)
        {
            GameModeManager.Instance.ActivateGameModes();
        }
    }

    public Transform GetTargetUITransform(UITargetZone zone)
    {
        return canvasZoneRegistry.GetTargetUIContainer(zone);
    }

    public AdBuilder GetTargetAdBuilder()
    {
        return adBuilder;
    }
}