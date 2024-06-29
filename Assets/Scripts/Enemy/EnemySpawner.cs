using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs; // Changed to plural for clarity
    public int enemyCount = 25;
    public float areaRadius = 60f;
    public float areaHeight = 10f;
    public LayerMask groundLayer;

    private void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = GetSpawnPoint();
        if (spawnPosition != Vector3.zero)
        {
            GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]; // Select a random enemy prefab
            GameObject newEnemy = Instantiate(randomEnemyPrefab, spawnPosition, Quaternion.identity);
            newEnemy.transform.SetParent(this.transform);
            newEnemy.GetComponent<Enemy>().SetRadiusHeigth(areaRadius, areaHeight);
        }
        else
        {
            Debug.LogWarning("Failed to find a valid spawn position for an enemy.");
        }
    }

    private Vector3 GetSpawnPoint()
    {
        Vector3 spawnPos = Vector3.zero;
        Vector3 center = transform.position;

        // Generate a random point within the specified area
        float randomAngle = Random.Range(0f, 360f);
        float randomRadius = Random.Range(0f, areaRadius);
        Vector3 randomDirection = Quaternion.Euler(0, randomAngle, 0) * Vector3.right;
        spawnPos = center + randomDirection * randomRadius;
        spawnPos.y = center.y + areaHeight;

        // Raycast downwards to find the ground position
        RaycastHit hit;
        if (Physics.Raycast(spawnPos, -transform.up, out hit, areaHeight, groundLayer))
        {
            spawnPos = hit.point;
        }
        else
        {
            Debug.LogWarning("Failed to find a valid spawn position for an enemy.");
        }

        return spawnPos;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, 0.5f);

        Vector3 center = transform.position;

        // Draw the circle outline
        Vector3 lastPos = center + Vector3.right * areaRadius;
        float angleStep = 360f / 50f;
        for (float angle = angleStep; angle <= 360; angle += angleStep)
        {
            Vector3 nextPos = center + Quaternion.Euler(0, angle, 0) * Vector3.right * areaRadius;

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(lastPos, nextPos);
            Gizmos.DrawLine(lastPos + Vector3.up * areaHeight, nextPos + Vector3.up * areaHeight);

            lastPos = nextPos;
        }
    }
}
