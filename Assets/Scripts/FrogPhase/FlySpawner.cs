using UnityEngine;
using TMPro;

public class FlySpawner : MonoBehaviour
{
    [SerializeField] GameObject flyPrefab;                    // Префаб мухи
    [SerializeField] float spawnInterval = 2f;                // Интервал между спавнами
    public int maxFlies = 10;                       // Максимум мух на сцене
    public Vector2 spawnArea = new Vector2(8f, 5f); // Область появления
    public TextMeshProUGUI counterText;             // UI-счётчик мух
    public GameObject beePrefab;
    public float beeSpawnInterval = 4f;
    public int maxBees = 3;
    public GameObject goldFlyPrefab; // Префаб золотой мухи
    [Range(0f, 1f)]
    public float goldFlyChance = 0.1f;


    private float timer;
    public int flyCount;//екущее количество мух на сцене
    private float beeTimer;


    void Start()
    {
        // Найдём всех мух, уже находящихся на сцене
        Fly[] existingFlies = FindObjectsOfType<Fly>();

        // Назначим каждой мухе ссылку на спавнер
        foreach (Fly fly in existingFlies)
        {
            fly.SetSpawner(this);
        }
    }

    void Update()
    {
        // Спавн мух
        timer += Time.deltaTime;
        if (timer >= spawnInterval && flyCount < maxFlies)
        {
            SpawnFly();
            timer = 0f;
        }

        // Спавн пчёл
        beeTimer += Time.deltaTime;
        if (beeTimer >= beeSpawnInterval)
        {
            SpawnBee();
            beeTimer = 0f;
        }

        // UI обновление
        if (counterText != null)
            counterText.text = $"{flyCount}";

    }

    void SpawnFly()
    {
        if (flyPrefab == null) return;

        // Генерация случайной позиции в пределах экрана
        float x = Random.Range(0.1f, 0.9f);
        float y = Random.Range(0.2f, 0.8f);

        // Глубина спавна мух (Z = 116.8)
        float spawnDepth = 126.8f;

        // Получаем мировую позицию на нужной глубине
        Vector3 viewportPos = new Vector3(x, y, spawnDepth - Camera.main.transform.position.z);
        Vector3 spawnPos = Camera.main.ViewportToWorldPoint(viewportPos);

        GameObject prefabToSpawn = Random.value < goldFlyChance ? goldFlyPrefab : flyPrefab;

        GameObject newFly = Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);

        Fly flyScript = newFly.GetComponent<Fly>();
        if (flyScript != null)
        {
            flyScript.SetSpawner(this);
        }

    }



    void SpawnBee()
    {
        if (beePrefab == null) return;

        // Генерация случайной позиции в пределах экрана
        float x = Random.Range(0.1f, 0.9f);
        float y = Random.Range(0.2f, 0.8f);

        // Глубина спавна пчёл (та же, что и у мух)
        float spawnDepth = 126.8f;

        // Переводим экранные координаты в мировые
        Vector3 viewportPos = new Vector3(x, y, spawnDepth - Camera.main.transform.position.z);
        Vector3 spawnPos = Camera.main.ViewportToWorldPoint(viewportPos);

        GameObject newBee = Instantiate(beePrefab, spawnPos, Quaternion.identity);

        Bee beeScript = newBee.GetComponent<Bee>();
        if (beeScript != null)
        {
            beeScript.SetSpawner(this);
        }
    }



    public void OnFlyDestroyed()
    {
        //if (fly
    }

    public void OnBeeDestroyed()
    {

    }

    public void OnGoldenFlyDestroyed()
    {
        flyCount += 5;
    }
}
