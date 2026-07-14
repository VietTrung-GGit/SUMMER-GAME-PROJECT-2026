using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "AdAction", menuName = "Ad/AdAction")]
public class AdAction : ScriptableObject
{
    [SerializeField] private Image icon;
    //[SerializeField] private AdActionType type;
    [SerializeField] private ConfirmAction action;
    public Sprite AdActionIcon => icon.sprite;
    //public AdActionType AdActionEnum => type;
    public ConfirmAction AdConfirmAction => action;
}
