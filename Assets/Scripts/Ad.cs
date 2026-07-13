using System;
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

    public void SetConfirmAction(Action<double> action, double amount)
    {
        confirmButton.onClick.RemoveAllListeners();
        confirmButton.onClick.AddListener(() => action?.Invoke(amount));
    }

    private void OnDisable()
    {
        titleIcon.sprite = null;
        actionIcon.sprite = null;
        confirmButton.onClick.RemoveAllListeners();
    }
}
