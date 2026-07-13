using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class AdAction : ScriptableObject
{
    [SerializeField] private Image icon;
    [SerializeField] private AdActionType type;
}
