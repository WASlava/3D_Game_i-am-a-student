using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    [SerializeField] private CharacterController controller;
    private Animator animator;
    private Vector3 move;

    void Start()
    {
        //controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Збираємо введення для руху
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        move = new Vector3(moveX, 0, moveZ).normalized; // Нормалізуємо для запобігання діагональних зсувів

        // Переміщуємо гравця
        controller.Move(move * speed * Time.deltaTime);

        // Якщо гравець рухається
        if (move.magnitude > 0)
        {
            animator.SetFloat("MoveSpeed", move.magnitude); // Встановлюємо швидкість для анімації
            animator.speed = 1f; // Повертаємо нормальну швидкість анімації

            // Якщо рух назад (Z < 0), інвертуємо анімацію по осі X
            if (moveZ < 0)
            {
                // Інвертуємо напрямок анімації, змінюючи масштаб по осі X
                transform.localScale = new Vector3(-1f, 1f, 1f); // Встановлюємо інвертований масштаб по осі X
            }
            else
            {
                // Встановлюємо масштаб по осі X в нормальний стан для руху вперед
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
        else
        {
            // Якщо гравець не рухається, ставимо анімацію на паузу
            animator.SetFloat("MoveSpeed", 0f); // Зупиняємо анімацію руху
            animator.speed = 0f; // Ставимо анімацію на паузу, не зупиняючи її
        }
    }
}
