using UnityEngine;

public class ShootHandler3D : MonoBehaviour
{
    public float hitRadius = 100f;
    public string targetTag = "Fly";
    public Camera mainCamera;
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
            // Позиция UI-прицела в экранных координатах
            Vector2 screenAimPos = RectTransformUtility.WorldToScreenPoint(mainCamera, aimRect.position);

            GameObject[] flies = GameObject.FindGameObjectsWithTag(targetTag);

            bool hit = false;

            foreach (GameObject fly in flies)
            {
                Vector3 flyScreenPos = mainCamera.WorldToScreenPoint(fly.transform.position);

                float distance = Vector2.Distance(screenAimPos, flyScreenPos);

                if (distance <= hitRadius)
                {
                    Destroy(fly);
                    score++;
                    Debug.Log("HIT! Score: " + score);
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