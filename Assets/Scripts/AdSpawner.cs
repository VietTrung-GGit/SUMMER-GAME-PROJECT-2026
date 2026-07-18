using System;
using System.Collections.Generic;
using UnityEngine;

public class AdSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private float baseMaxSpawnInterval = 1.0f;
    [SerializeField] private AdBuilder goodAdBuilder;
    [SerializeField] private AdBuilder badAdBuilder;
    [SerializeField] private AdBuilder modifierAdBuilder;
    //[SerializeField] private TimeTracker gameTimeTracker;
    [SerializeField] private StatTracker speedModifierTracker;
    private float spawnTimeRemaining;
    private float currentMaxSpawnInterval;
    //private const float SPEED_UP_VALUE = 0.75f;
    private const int MAX_POOL_SIZE = 50;
    /*private const float MIN_WIDTH_SAFE_SPAWN_SPACE = 80.0f;
    private const float MIN_HEIGHT_SAFE_SPAWN_SPACE = 45.0f;*/
    private const float SAFE_SPAWN_SPACE_PERCENTAGE = 0.75f;
    //Ensure type safety and prevent lagging
    private Transform[] adPool = new Transform[MAX_POOL_SIZE];
    private const string GOOD_AD_KEYWORD = "GoodAd";
    private const string BAD_AD_KEYWORD = "BadAd";
    private const string MODIFIER_AD_KEYWORD = "ModifierAd";
    private const string BLOCKING_AD_KEYWORD = "BlockingAd";
    /*private readonly Dictionary<string, float> adWeightList = new Dictionary<string, float>()
    {
        {MODIFIER_AD_KEYWORD, 0.1f},
        {BAD_AD_KEYWORD, 0.3f},
        {GOOD_AD_KEYWORD, 0.6f},
    };*/
    private readonly Dictionary<string, float> adWeightList = new Dictionary<string, float>()
    {
        {GOOD_AD_KEYWORD, 0.1f},
        {BAD_AD_KEYWORD, 0.9f}
    };

    private void Awake()
    {
        //adPool = gameCanvas.GetComponentsInChildren<Transform>(true);
        int index = 0;
        foreach (Transform ad in gameCanvas.transform)
        {
            if (index == MAX_POOL_SIZE)
            {
                break;
            }
            adPool[index] = ad;
            index++;
        }
        currentMaxSpawnInterval  = baseMaxSpawnInterval;
        spawnTimeRemaining = currentMaxSpawnInterval;
    }

    private void OnEnable()
    {
        //gameTimeTracker.OnTimeCountExpired += OnGameTimerExpired;
        speedModifierTracker.OnStatCountChanged += OnSpeedModifierChanged;
    }

    private void OnDisable()
    {
        //gameTimeTracker.OnTimeCountExpired -= OnGameTimerExpired;
        speedModifierTracker.OnStatCountChanged -= OnSpeedModifierChanged;
    }
    private void Update()
    {
        spawnTimeRemaining -= Time.deltaTime;
        if (spawnTimeRemaining <= 0.0f)
        {
            //Debug.Log("Spawn Ad!");
            SpawnAd();
            spawnTimeRemaining = currentMaxSpawnInterval;
        }
    }

    private void SpawnAd()
    {
        Transform targetAdTransform = null;
        foreach (Transform ad in adPool)
        {
            if (!ad)
            {
                break;
            }

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
            Vector2 randomPosition = new Vector2(UnityEngine.Random.Range(-Screen.width/2 * SAFE_SPAWN_SPACE_PERCENTAGE, Screen.width/2 * SAFE_SPAWN_SPACE_PERCENTAGE), UnityEngine.Random.Range(-Screen.height/2 * SAFE_SPAWN_SPACE_PERCENTAGE, Screen.height/2 * SAFE_SPAWN_SPACE_PERCENTAGE));
            adRectTransform.anchoredPosition = randomPosition;
        }
    }

    private void ConstructAd(AdBuilder builder, Ad targetAd)
    {
        builder.Randomize();
        builder.BuildAdTimer(targetAd);
        builder.BuildIcon(targetAd);
        //builder.BuildActionIcon(targetAd);
        builder.BuildAdButtonActions(targetAd);
    }

    /*private void OnGameTimerExpired()
    {
        maxSpawnInterval *= SPEED_UP_VALUE;
    }*/
    private void OnSpeedModifierChanged(double amount)
    {
        currentMaxSpawnInterval = baseMaxSpawnInterval/(float)speedModifierTracker.StatCount;
    }
}
