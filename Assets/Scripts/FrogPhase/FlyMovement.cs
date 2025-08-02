using UnityEngine;

public class FlyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float directionChangeInterval = 1f;
    public float boundary = 5f; // ����������� ����� �� X � Y

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

        // ��������
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // �������� ���� �����
        Vector3 clamped = new Vector3(
            Mathf.Clamp(transform.position.x, -boundary, boundary),
            Mathf.Clamp(transform.position.y, -boundary, boundary),
            transform.position.z
        );
        transform.position = clamped;
    }

    void ChangeDirection()
    {
        // ��������� ��������� ��������� ����������
        float angle = Random.Range(0f, 360f);
        moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
    }
}
