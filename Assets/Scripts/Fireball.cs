using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private int damage = 10;


    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
        Destroy(this.gameObject);
    }
}
