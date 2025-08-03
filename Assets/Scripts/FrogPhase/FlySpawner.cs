using UnityEngine;
using TMPro;

public class FlySpawner : MonoBehaviour
{
    [SerializeField] GameObject flyPrefab;                    // ������ ����
    [SerializeField] float spawnInterval = 2f;                // �������� ����� ��������
    public int maxFlies = 10;                       // �������� ��� �� �����
    public Vector2 spawnArea = new Vector2(8f, 5f); // ������� ���������
    public TextMeshProUGUI counterText;             // UI-������� ���
    public GameObject beePrefab;
    public float beeSpawnInterval = 4f;
    public int maxBees = 3;
    public GameObject goldFlyPrefab; // ������ ������� ����
    [Range(0f, 1f)]
    public float goldFlyChance = 0.1f;


    private float timer;
    public int flyCount;//������ ���������� ��� �� �����
    private float beeTimer;


    void Start()
    {
        // ����� ���� ���, ��� ����������� �� �����
        Fly[] existingFlies = FindObjectsOfType<Fly>();

        // �������� ������ ���� ������ �� �������
        foreach (Fly fly in existingFlies)
        {
            fly.SetSpawner(this);
        }
    }

    void Update()
    {
        // ����� ���
        timer += Time.deltaTime;
        if (timer >= spawnInterval && flyCount < maxFlies)
        {
            SpawnFly();
            timer = 0f;
        }

        // ����� ����
        beeTimer += Time.deltaTime;
        if (beeTimer >= beeSpawnInterval)
        {
            SpawnBee();
            beeTimer = 0f;
        }

        // UI ����������
        if (counterText != null)
            counterText.text = $"{flyCount}";

    }

    void SpawnFly()
    {
        if (flyPrefab == null) return;

        Vector3 spawnOffset = new Vector3(
            Random.Range(-spawnArea.x, spawnArea.x),
            Random.Range(-spawnArea.y, spawnArea.y),
            0f
        );

        Vector3 spawnPos = transform.position + spawnOffset;

        // �������� ������� ��� ������� ����
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

        Vector3 spawnOffset = new Vector3(
            Random.Range(-spawnArea.x, spawnArea.x),
            Random.Range(-spawnArea.y, spawnArea.y),
            0f
        );

        Vector3 spawnPos = transform.position + spawnOffset;

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
