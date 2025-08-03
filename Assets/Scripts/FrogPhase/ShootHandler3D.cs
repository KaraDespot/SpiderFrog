using UnityEngine;

public class ShootHandler3D : MonoBehaviour
{
    [SerializeField] float hitRadius = 100f;
    [SerializeField] string targetTag = "Fly";
    [SerializeField] Camera mainCamera;
    [SerializeField] FlySpawner flySpawner; // Ссылка на спавнер мух, если нужно
    public int score = 0;

    private RectTransform aimRect;

    void Start()
    {
        aimRect = GetComponent<RectTransform>();

        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 screenAimPos = RectTransformUtility.WorldToScreenPoint(mainCamera, aimRect.position);

            GameObject[] allTargets = GameObject.FindGameObjectsWithTag(targetTag);

            bool hit = false;

            foreach (GameObject target in allTargets)
            {
                Vector3 targetScreenPos = mainCamera.WorldToScreenPoint(target.transform.position);

                float distance = Vector2.Distance(screenAimPos, targetScreenPos);

                if (distance <= hitRadius)
                {
                    // Проверка на золотую муху
                    if (target.GetComponent<GoldenFly>() != null)
                    {

                        flySpawner.flyCount += 5; // например, 5 очков за золотую
                        Debug.Log("GOLDEN HIT! Score: " + flySpawner.flyCount);
                    }
                    if (target.GetComponent<Fly>() != null)
                    {

                        flySpawner.flyCount += 1; // например, 5 очков за золотую
                        Debug.Log("HIT! Score: " + flySpawner.flyCount);
                    }
                    else
                    {
                        flySpawner.flyCount -= 0;
                        Debug.Log("HIT! Score: " + flySpawner.flyCount);
                    }

                    Destroy(target);
                    hit = true;
                    break;
                }
            }

            if (!hit)
            {
                Debug.Log("MISS! ScreenAimPos: " + screenAimPos);
            }
        }
    }
}
