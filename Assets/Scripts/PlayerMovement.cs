using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    [SerializeField] private CharacterController controller;
    private Animator animator;
    private Vector3 move;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        move = new Vector3(moveX, 0, moveZ).normalized; 

        controller.Move(move * speed * Time.deltaTime);

        if (move.magnitude > 0)
        {
            animator.SetFloat("MoveSpeed", move.magnitude); 
            animator.speed = 1f;


        }
        else
        {
            animator.SetFloat("MoveSpeed", 0f);
            animator.speed = 0f;
        }
    }
}
