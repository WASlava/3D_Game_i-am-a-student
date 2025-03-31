using UnityEngine;

public class Fireball2 : MonoBehaviour
{
    [SerializeField] private float speed = 20f;

    [SerializeField] private int damage = 10;


    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<ReactiveEnemy>()?.TakeDamage(damage);
            Destroy(this.gameObject);      
        }
        else if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerCharacter>()?.TakeDamage(damage);
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }

    }
}
