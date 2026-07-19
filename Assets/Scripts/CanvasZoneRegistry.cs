using UnityEngine;
public class CanvasZoneRegistry : MonoBehaviour
{
    [SerializeField] private Transform activeModifiersPanel;
    [SerializeField] private Transform activeMechanicsPanel;
    [SerializeField] private Transform stackableGameScreenOverlay;
    [SerializeField] private Transform staticGameScreenOverlay;
    /*public static CanvasZoneRegistry Instance {get; private set;}
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
    }*/

    public Transform GetTargetUIContainer(UITargetZone targetZone)
    {
        return targetZone switch
        {
            UITargetZone.ActiveModifiersPanel => activeModifiersPanel,
            UITargetZone.ActiveMechanicsPanel => activeMechanicsPanel,
            UITargetZone.StackableGameScreenOverlay => stackableGameScreenOverlay,
            UITargetZone.StaticGameScreenOverlay => staticGameScreenOverlay,
            _ => transform
        };
    }
}