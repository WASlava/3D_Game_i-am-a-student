using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float damage = 10.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            //Debug.Log("Player is destroyed");
            player.TakeDamage(damage);
        }
        Destroy(this.gameObject);
    }
}
