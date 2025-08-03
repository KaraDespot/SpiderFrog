using UnityEngine;

public class FlySpawner : MonoBehaviour
{
    public GameObject flyPrefab;          // Префаб мухи
    public int maxFlies = 10;             // Максимальное количество мух
    public float spawnInterval = 2f;      // Интервал между спавнами
    public Vector2 spawnArea = new Vector2(5f, 5f); // Область спавна

    private int currentFlyCount = 0;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && currentFlyCount < maxFlies)
        {
            SpawnFly();
            timer = 0f;
        }
    }

    void SpawnFly()
    {
        Vector3 spawnPos = new Vector3(
            Random.Range(-spawnArea.x, spawnArea.x),
            Random.Range(-spawnArea.y, spawnArea.y),
            0f
        );

        Instantiate(flyPrefab, transform.position + spawnPos, Quaternion.identity);
        currentFlyCount++;
    }
}
