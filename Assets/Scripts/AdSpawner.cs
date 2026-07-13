using UnityEngine;

public class AdSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private float maxSpawnInterval = 2.0f;
    private float spawnTimeRemaining;
    private float screenWidth;
    private float screenHeight;
    //Ensure type safety and prevent lagging
    private Transform[] adPool = new Transform[50];
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
        foreach (Transform ad in adPool)
        {
            if (!ad.gameObject.activeSelf)
            {
                ad.gameObject.SetActive(true);
                ad.SetAsLastSibling();
                RectTransform adRectTransform = ad.gameObject.GetComponent<RectTransform>();
                Vector2 randomPosition = new Vector2(Random.Range(-screenWidth/2, screenWidth/2), Random.Range(-screenHeight/2, screenHeight/2));
                adRectTransform.anchoredPosition = randomPosition;
                break;
            }
        }
    }
}
