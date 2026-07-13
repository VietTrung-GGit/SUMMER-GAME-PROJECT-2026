using System;
using System.Collections.Generic;
using UnityEngine;

public class AdSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private float maxSpawnInterval = 2.0f;
    [SerializeField] private GoodAdBuilder goodAdBuilder;
    [SerializeField] private BadAdBuilder badAdBuilder;
    [SerializeField] private ModifierAdBuilder modifierAdBuilder;
    private float spawnTimeRemaining;
    private float screenWidth;
    private float screenHeight;
    //Ensure type safety and prevent lagging
    private Transform[] adPool = new Transform[50];
    private const string GOOD_AD_KEYWORD = "GoodAd";
    private const string BAD_AD_KEYWORD = "BadAd";
    private const string MODIFIER_AD_KEYWORD = "ModifierAd";
    private readonly Dictionary<string, float> adWeightList = new Dictionary<string, float>()
    {
        {MODIFIER_AD_KEYWORD, 0.1f},
        {BAD_AD_KEYWORD, 0.3f},
        {GOOD_AD_KEYWORD, 0.6f},
    };

    private void Awake()
    {
        adPool = gameCanvas.GetComponentsInChildren<Transform>(true);
        spawnTimeRemaining = maxSpawnInterval;
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    private void Update()
    {
        spawnTimeRemaining -= Time.deltaTime;
        if (spawnTimeRemaining <= 0.0f)
        {
            SpawnAd();
            spawnTimeRemaining = maxSpawnInterval;
        }
    }

    private void SpawnAd()
    {
        Transform targetAdTransform = null;
        foreach (Transform ad in adPool)
        {
            if (!ad.gameObject.activeSelf)
            {
                targetAdTransform = ad;
                break;
            }
        }

        if (targetAdTransform)
        {
            float randomFloat = UnityEngine.Random.Range(0.0f, 1.0f);
            float cumulativeProbability = 0.0f;
            Ad targetAd = targetAdTransform.gameObject.GetComponent<Ad>();
            foreach (string key in adWeightList.Keys)
            {
                cumulativeProbability += adWeightList[key];
                if (cumulativeProbability >= randomFloat)
                {
                    if (String.Equals(key, MODIFIER_AD_KEYWORD))
                    {
                        ConstructAd(modifierAdBuilder, targetAd);
                    }
                    else if (String.Equals(key, BAD_AD_KEYWORD))
                    {
                        ConstructAd(badAdBuilder, targetAd);
                    }
                    else if (String.Equals(key, GOOD_AD_KEYWORD))
                    {
                        ConstructAd(goodAdBuilder, targetAd);
                    }
                    break;
                }
            }
            targetAdTransform.gameObject.SetActive(true);
            targetAdTransform.SetAsLastSibling();
            RectTransform adRectTransform = targetAd.gameObject.GetComponent<RectTransform>();
            Vector2 randomPosition = new Vector2(UnityEngine.Random.Range(-screenWidth/2, screenWidth/2), UnityEngine.Random.Range(-screenHeight/2, screenHeight/2));
            adRectTransform.anchoredPosition = randomPosition;
        }
    }

    private void ConstructAd(IAdBuilder builder, Ad targetAd)
    {
        builder.BuildTitleIcon(targetAd);
        builder.BuildActionIcon(targetAd);
    }
}
