using UnityEngine;

public class PlayerSpider : MonoBehaviour
{
    public float speed = 5f;
    public float turnSpeed = 20f;

    private Rigidbody rb;
    private Vector3 movement;
    private Animator animator;
    private Quaternion targetRotation = Quaternion.identity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveHorizontal, 0f, moveVertical);

        Vector3 newPosition = rb.position + movement * speed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);

        //bool isMoving = movement.magnitude > 0f;
        //animator.SetBool("isMoving", isMoving);

        if (movement != Vector3.zero)
        {
            Vector3 newDir = Vector3.RotateTowards(
                transform.forward,
                movement,
                turnSpeed * Time.deltaTime,
                0f
            );
            targetRotation = Quaternion.LookRotation(newDir);
        }

        //void OnAnimatorMove()
        //{
        //    rb.MovePosition(
        //        rb.position + movement * animator.deltaPosition.magnitude
        //    );

        //    rb.MoveRotation(targetRotation);
        //}
    }
}
