using UnityEngine;

public class Fireball2 : MonoBehaviour
{
    [SerializeField] private float speed = 20f;  // Ўвидк≥сть

    [SerializeField] private float damage = 10.0f;

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
            other.GetComponent<ReactiveEnemy>()?.TakeDamage((int)damage);
        }
        else if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerCharacter>()?.TakeDamage(damage);
        }
        Destroy(this.gameObject);
    }
}
