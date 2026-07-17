using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "AdMetadata", menuName = "Ad/AdMetadata")]
public class AdMetadata : ScriptableObject
{
    //[SerializeField] private Image icon;
    //[SerializeField] private AdActionType type;
    [SerializeField] private AdExecuteAction confirmAction;
    [SerializeField] private AdAction closeAction;
    [SerializeField] private AdExecuteAction timerAction;
    //public Sprite AdActionIcon => icon.sprite;
    //public AdActionType AdActionEnum => type;
    public AdExecuteAction AdConfirmAction => confirmAction;
    public AdAction AdCloseAction => closeAction;
    public AdExecuteAction AdTimerAction => timerAction;
}
