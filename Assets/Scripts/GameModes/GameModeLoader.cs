using System.Collections.Generic;
using UnityEngine;
public class GameModeLoader : MonoBehaviour
{
    [SerializeField] private CanvasZoneRegistry canvasZoneRegistry;
    [SerializeField] private AdBuilder adBuilder;
    [SerializeField] private AdSpawner adSpawner;
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

    public void SetUpAdBuilder(List<AdItem> adItemList, List<float> adWeightList)
    {
        adBuilder.SetUpAdItemDataSet(adItemList, adWeightList);
    }

    public void ActivateAdSpawner()
    {
        adSpawner.gameObject.SetActive(true);
    }
}