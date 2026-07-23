using System.Collections.Generic;
using UnityEngine;

public class CannonUpdater : MonoBehaviour
{
    [SerializeField] private float baseMaxShootInterval;
    [SerializeField] private StatTracker speedModifierTracker;
    [SerializeField] private List<SlicedItemSO> slicedItemSOList;
    [SerializeField] private List<float> slicedItemWeightList;
    private int targetItemIndex;
    private readonly Transform[] slicedItemPool = new Transform[10];
    private const float MAX_SHOOT_OFFSET = 5.0f;
    private const float MIN_FORCE_MULTIPLIER = 16.0f;
    private const float MAX_FORCE_MULTIPLIER = 14.0f;
    private float currentMaxShootInterval;
    private float shootTimeRemaining;
    private void OnEnable()
    {
        speedModifierTracker.OnStatCountChanged += OnSpeedModifierChanged;
    }

    private void OnDisable()
    {
        speedModifierTracker.OnStatCountChanged -= OnSpeedModifierChanged;
    }
    private void Awake()
    {
        int index = 0;
        foreach (Transform child in transform)
        {
            slicedItemPool[index] = child;
            index++;
        }

        shootTimeRemaining = baseMaxShootInterval;
        currentMaxShootInterval = baseMaxShootInterval;
    }

    private void Update()
    {
        shootTimeRemaining -= Time.deltaTime;
        if (shootTimeRemaining <= 0.0f)
        {
            ShootProjectile();
            shootTimeRemaining = currentMaxShootInterval;
        }
    }

    private void Randomize()
    {
        float randomFloat = Random.Range(0.0f, 1.0f);
        float cumulativeProbability = 0.0f;
        for (int index = 0; index < slicedItemWeightList.Count; index++)
        {
            cumulativeProbability += slicedItemWeightList[index];
            if (cumulativeProbability >= randomFloat)
            {
                targetItemIndex = index;
                break;
            }
        }
    }
    private void ShootProjectile()
    {
        Randomize();

        foreach (Transform slicedItem in slicedItemPool)
        {
            if (!slicedItem.gameObject.activeSelf)
            {
                if (slicedItem.TryGetComponent<SlicedItem>(out var targetComponent))
                {
                    targetComponent.SetUpSlicedItem(slicedItemSOList[targetItemIndex]);
                }
                float randomOffset = Random.Range(-MAX_SHOOT_OFFSET, MAX_SHOOT_OFFSET);
                float randomForceMult = Random.Range(MIN_FORCE_MULTIPLIER, MAX_FORCE_MULTIPLIER);
                slicedItem.position = new Vector2(transform.position.x + randomOffset, transform.position.y);
                slicedItem.gameObject.SetActive(true);
                if (slicedItem.gameObject.TryGetComponent<Rigidbody2D>(out var rbSlicedBomb))
                {
                    rbSlicedBomb.AddForce(Vector2.up * randomForceMult, ForceMode2D.Impulse);
                }
                break;
            }
        }
    }

    private void OnSpeedModifierChanged(double amount)
    {
        currentMaxShootInterval = baseMaxShootInterval/(float)speedModifierTracker.StatCount;
    }
}