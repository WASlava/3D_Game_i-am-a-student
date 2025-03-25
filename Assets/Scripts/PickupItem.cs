using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] private PlayerCharacter player;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCharacter player = other.GetComponent<PlayerCharacter>();
            if (player == null)
            {
                Debug.LogError("PlayerCharacter component not found on Player!");
                return;
            }

            if (gameObject.CompareTag("Ammo"))
            {
                player.AddAmmo(10);
                Debug.Log("Item Ammo picked up!");
            }
            else if (gameObject.CompareTag("MedBox"))
            {
                player.Heal(10);
                Debug.Log("Item Health picked up!");
            }
            Destroy(gameObject);
        }
        else if (other.CompareTag("Enemy") && gameObject.CompareTag("MedBox"))
        {
            ReactiveEnemy enemy = other.GetComponent<ReactiveEnemy>();
            if (enemy == null)
            {
                Debug.LogError("ReactiveEnemy component not found on Enemy!");
                return;
            }

            enemy.Heal(20);
            Destroy(gameObject);
            Debug.Log("Enemy healed!");
        }
    }

}

