
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [Header("Rock Prefab")]
    [SerializeField] private GameObject rockPrefab;

    [Header("Spawn Settings")]
    [SerializeField] private float minSpawnInterval = 2f;
    [SerializeField] private float maxSpawnInterval = 4f;
    [SerializeField] private float spawnRadius = 1f;

    private void Start()
    {
        if (rockPrefab == null)
        {
            Debug.LogError("Rock prefab is not assigned!");
            return;
        }

        SpawnRock();
    }

    private void SpawnRock()
    {
        Vector3 randomOffset = new Vector3(
            Random.Range(-spawnRadius, spawnRadius),
            0f,
            Random.Range(-spawnRadius, spawnRadius)
        );

        Instantiate(
            rockPrefab,
            transform.position + randomOffset,
            Quaternion.identity
        );

        float nextSpawn = Random.Range(
            minSpawnInterval,
            maxSpawnInterval
        );

        Invoke(nameof(SpawnRock), nextSpawn);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
