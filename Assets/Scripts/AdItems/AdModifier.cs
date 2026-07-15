using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "AdModifier", menuName = "Ad/AdModifier")]
public class AdModifier : ScriptableObject
{
    [SerializeField] private Image icon;
    [SerializeField] private double value;
    [SerializeField] private AdAction adAction;
    [SerializeField] private ViewValue viewValue;
    [SerializeField] private LikeValue likeValue;
    public Sprite AdModifierIcon => icon.sprite;
    public double AdModifierValue => value;
    public AdAction AdModifierAction => adAction;
    public ViewValue AdModifierViewValue => viewValue;
    public LikeValue AdModifierLikeValue => likeValue;
}
