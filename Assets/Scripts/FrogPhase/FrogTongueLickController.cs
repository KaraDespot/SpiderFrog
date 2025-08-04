using UnityEngine;

public class FrogTongueLickController : MonoBehaviour
{
    [SerializeField] private Animator tongueAnimator; // �������� �����

    void Start()
    {
        if (tongueAnimator == null)
            tongueAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tongueAnimator.SetTrigger("Lick");
        }
    }
}