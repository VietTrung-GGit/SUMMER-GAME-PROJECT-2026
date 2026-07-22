using UnityEngine;

public class CannonUpdater : MonoBehaviour
{
    [SerializeField] private float baseMaxShootInterval;
    [SerializeField] private StatTracker speedModifierTracker;
    private Transform[] slicedBombPool = new Transform[10];
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
            slicedBombPool[index] = child;
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

    private void ShootProjectile()
    {
        foreach (Transform slicedBomb in slicedBombPool)
        {
            if (!slicedBomb.gameObject.activeSelf)
            {
                float randomOffset = Random.Range(-MAX_SHOOT_OFFSET, MAX_SHOOT_OFFSET);
                float randomForceMult = Random.Range(MIN_FORCE_MULTIPLIER, MAX_FORCE_MULTIPLIER);
                slicedBomb.position = new Vector2(transform.position.x + randomOffset, transform.position.y);
                slicedBomb.gameObject.SetActive(true);
                if (slicedBomb.gameObject.TryGetComponent<Rigidbody2D>(out var rbSlicedBomb))
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