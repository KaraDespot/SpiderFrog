using UnityEngine;

public class PlayerSpider : MonoBehaviour
{
    public float speed = 5f;
    public float turnSpeed = 20f;

    private Rigidbody rb;
    private Vector3 movement;
    private Animator animator;
    private Quaternion targetRotation = Quaternion.identity;
    private Vector3 lastPosition; // Для компенсации root motion

    [SerializeField] private Attack Attack;
    [SerializeField] private float flyAttackCooldown = 2f;
    private float lastFlyAttackTime;

    private HealthBar healthBar;
    private bool isDead = false; // Добавляем флаг смерти

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Ищем аниматор на текущем объекте или в дочерних объектах
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
            if (animator == null)
            {
                Debug.LogError("Animator не найден ни на объекте, ни в дочерних объектах!");
                return;
            }
            Debug.Log("Найден аниматор в дочернем объекте: " + animator.name);
        }
        
        healthBar = GetComponent<HealthBar>();
        
        // Инициализируем параметр IsAlive как true при старте
        if (animator != null)
        {
            animator.SetBool("IsAlive", true);
            animator.SetBool("IsWalking", false);
        }
        
        // Запоминаем начальную позицию для компенсации root motion
        lastPosition = transform.position;
    }

    void FixedUpdate()
    {
        // Блокируем движение, если паук мёртв
        if (isDead) return;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveHorizontal, 0f, moveVertical);

        Vector3 newPosition = rb.position + movement * speed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);

        bool isWalking = movement.magnitude > 0f;
        if (animator != null)
        {
            animator.SetBool("IsWalking", isWalking);
        }

        // Исправляем поворот персонажа
        if (movement != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
    }

    void Update()
    {
        if (animator == null) return;

        // Блокируем атаки, если паук мёртв
        if (isDead) return;

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
            if (Attack != null)
            {
                Attack.OnAttack();
            }
        }

        if (Input.GetMouseButtonDown(1) && Time.time >= lastFlyAttackTime + flyAttackCooldown)
        {
            animator.SetTrigger("FlyAttack");
            // Здесь вызовите ваш дальний атаку (например, стрельба паутиной)
            lastFlyAttackTime = Time.time;
        }

        // Проверка на смерть
        if (healthBar != null && healthBar.CurrentHealth <= 0 && !isDead)
        {
            Debug.Log($"Player Spider: Health reached 0, calling Die()");
            Die();
        }
    }
    
    void LateUpdate()
    {
        // Компенсация root motion - возвращаем паука на место, если он сдвинулся из-за анимации
        if (animator != null && !animator.GetBool("IsWalking"))
        {
            Vector3 currentPosition = transform.position;
            Vector3 rootMotionOffset = currentPosition - lastPosition;
            
            // Если паук сдвинулся по X или Z без нашего движения, возвращаем его назад
            if (Mathf.Abs(rootMotionOffset.x) > 0.01f || Mathf.Abs(rootMotionOffset.z) > 0.01f)
            {
                Vector3 correctedPosition = new Vector3(lastPosition.x, currentPosition.y, lastPosition.z);
                transform.position = correctedPosition;
                rb.position = correctedPosition;
            }
        }
        
        lastPosition = transform.position;
    }

    // Новый метод для обработки смерти
    private void Die()
    {
        Debug.Log("Player Spider: Die() method called");
        isDead = true;
        
        if (animator != null)
        {
            animator.SetBool("IsAlive", false);
        }

        // Вызываем GameOver
        if (GameOverManager.Instance != null)
        {
            Debug.Log("Player Spider: Calling GameOverManager.Instance.GameOver()");
            GameOverManager.Instance.GameOver();
        }
        else
        {
            Debug.LogError("Player Spider: GameOverManager.Instance is null!");
        }
    }
}