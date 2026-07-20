using System.Collections.Generic;
using UnityEngine;

public class BlindPanelUpdater : MonoBehaviour
{
    [SerializeField] private RectTransform topBlindPanel;
    [SerializeField] private RectTransform bottomBlindPanel;
    [SerializeField] private RectTransform leftBlindPanel;
    [SerializeField] private RectTransform rightBlindPanel;
    [SerializeField] private RectTransform blindTimerPanel;
    [SerializeField] private float maxIntervalTime;
    private float intervalRemaining;
    private bool isAnyBlindPanelActive = false;
    private enum PanelDirection
    {
        Top,
        Left,
        Bottom,
        Right
    }
    private readonly List<PanelDirection> panelDirectionList = new List<PanelDirection>()
    {
        PanelDirection.Top,
        PanelDirection.Left,
        PanelDirection.Bottom,
        PanelDirection.Right
    };

    private readonly Dictionary<PanelDirection, RectTransform> blindPanelDict = new Dictionary<PanelDirection, RectTransform>();
    
    private void Awake()
    {
        blindPanelDict.Add(PanelDirection.Top, topBlindPanel);
        blindPanelDict.Add(PanelDirection.Left, leftBlindPanel);
        blindPanelDict.Add(PanelDirection.Bottom, bottomBlindPanel);
        blindPanelDict.Add(PanelDirection.Right, rightBlindPanel);
    }
    private void Update()
    {
        if (!isAnyBlindPanelActive)
        {
        intervalRemaining -= Time.deltaTime;
        if (intervalRemaining <= 0.0f)
        {
            TriggerBlindEvent();
            intervalRemaining = maxIntervalTime;
        }
        }
    }

    private void TriggerBlindEvent()
    {
        int randomIndex = Random.Range(0, panelDirectionList.Count);
        PanelDirection targetPanelDirection = panelDirectionList[randomIndex];
        RectTransform targetRectTransform = blindPanelDict[targetPanelDirection];
        targetRectTransform.SetAsLastSibling();
        switch (targetPanelDirection)
        {
            case PanelDirection.Top:
                targetRectTransform.anchoredPosition = new Vector2(0, -targetRectTransform.rect.height);
                break;
            case PanelDirection.Left:
                targetRectTransform.anchoredPosition = new Vector2(targetRectTransform.rect.width, 0);
                break;
            case PanelDirection.Bottom:
                targetRectTransform.anchoredPosition = new Vector2(0, targetRectTransform.rect.height);
                break;
            case PanelDirection.Right:
                targetRectTransform.anchoredPosition = new Vector2(-targetRectTransform.rect.width, 0);
                break;
        }

    }


}