using UnityEngine;
using UnityEngine.UI;

public class Ad : MonoBehaviour
{
    [SerializeField] private Image titleIcon;
    [SerializeField] private Image actionIcon;
    public void SetTitleIcon(Sprite newIcon)
    {
        titleIcon.sprite = newIcon;
    }

    public void SetActionIcon(Sprite newIcon)
    {
        actionIcon.sprite = newIcon;
    }
}
