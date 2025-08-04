using UnityEngine;

public class FrogLickController : MonoBehaviour
{
    [SerializeField] private Animator animator; // ѕеретащите сюда аниматор л€гушки или €зыка

    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Lick");
        }
    }
}