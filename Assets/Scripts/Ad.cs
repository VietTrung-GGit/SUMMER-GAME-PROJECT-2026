using System;
using UnityEngine;
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

    //Generic type T is used for double, ViewValue and LikeValue in concrete AdBuilder
    public void SetConfirmAction<T>(Action<T> action, T amount)
    {
        //Debug.Log("Set Confirm Action!");
        if (action == null)
        {
            Debug.Log("Null found!");
        }
        confirmButton.onClick.AddListener(() => action?.Invoke(amount));
    }

    private void OnDisable()
    {
        titleIcon.sprite = null;
        actionIcon.sprite = null;
        confirmButton.onClick.RemoveAllListeners();
    }
}
