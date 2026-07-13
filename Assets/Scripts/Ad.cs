using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Ad : MonoBehaviour
{
    [SerializeField] private Image titleIcon;
    [SerializeField] private Image actionIcon;
    [SerializeField] private Button confirmButton;
    public void SetTitleIcon(Sprite newIcon)
    {
        titleIcon.sprite = newIcon;
    }

    public void SetActionIcon(Sprite newIcon)
    {
        actionIcon.sprite = newIcon;
    }

    public void SetConfirmAction(UnityAction action)
    {
        confirmButton.onClick.RemoveAllListeners();
        confirmButton.onClick.AddListener(action);
    }

    private void OnDisable()
    {
        titleIcon.sprite = null;
        actionIcon.sprite = null;
        confirmButton.onClick.RemoveAllListeners();
    }
}
