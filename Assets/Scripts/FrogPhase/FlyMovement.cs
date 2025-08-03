using UnityEngine;

public class FlyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float directionChangeInterval = 1f;
    public float boundary = 5f; // ограничение полёта по X и Y

    private Vector2 moveDirection;
    private float timer;

    void Start()
    {
        ChangeDirection();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= directionChangeInterval)
        {
            ChangeDirection();
            timer = 0f;
        }

        // Движение
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // Ограничи зону полёта
        Vector3 clamped = new Vector3(
            Mathf.Clamp(transform.position.x, -boundary, boundary),
            Mathf.Clamp(transform.position.y, -boundary, boundary),
            transform.position.z
        );
        transform.position = clamped;
    }

    void ChangeDirection()
    {
        // Рандомная единичная векторная траектория
        float angle = Random.Range(0f, 360f);
        moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
    }
}
