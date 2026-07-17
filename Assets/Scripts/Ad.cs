using System;
using UnityEngine;
using UnityEngine.UI;

public class Ad : MonoBehaviour
{
    [SerializeField] private Image titleIcon;
    [SerializeField] private Image actionIcon;
    [SerializeField] private Button confirmButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private AdTimer adTimer;

    public void SetAdTimer(float lifeTime, Action<double> action, double actionParam)
    {
        adTimer.SetMaxTime(lifeTime);
        adTimer.SetTimerExpiredAction(action, actionParam);
    }
    public void SetTitleIcon(Sprite newIcon)
    {
        titleIcon.sprite = newIcon;
    }

    public void SetActionIcon(Sprite newIcon)
    {
        actionIcon.sprite = newIcon;
    }

    //Generic type T is used for double, ViewValue and LikeValue in concrete AdBuilder
    public void SetConfirmAction(Action<double> action, double amount)
    {
        confirmButton.gameObject.SetActive(true);
        confirmButton.onClick.AddListener(() => action?.Invoke(amount));
    }

    public void SetCloseButton(Action<double> action, double amount)
    {
        closeButton.gameObject.SetActive(true);
        closeButton.onClick.AddListener(() => action?.Invoke(amount));
    }

    private void OnDisable()
    {
        titleIcon.sprite = null;
        actionIcon.sprite = null;
        confirmButton.onClick.RemoveAllListeners();
        confirmButton.gameObject.SetActive(false);
        closeButton.onClick.RemoveAllListeners();
        closeButton.gameObject.SetActive(false);
    }
}
