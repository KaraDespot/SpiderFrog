using UnityEngine;

public class TargetMoverUI : MonoBehaviour
{
    public RectTransform targetRect;
    public float A = 400f; // ширина бесконечности
    public float B = 300f; // высота
    public float speed = 1f;
    public float a = 1f;
    public float b = 2f;
    public float delta = Mathf.PI / 2;

    private float t;

    void Update()
    {
        t += Time.deltaTime * speed;

        float x = A * Mathf.Sin(a * t + delta);
        float y = B * Mathf.Sin(b * t);

        if (targetRect != null)
        {
            targetRect.anchoredPosition = new Vector2(x, y);
        }
    }
}
