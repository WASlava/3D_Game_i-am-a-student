using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCharacter player = other.GetComponent<PlayerCharacter>();
            if (player == null)
            {
                Debug.LogError("PlayerCharacter component not found on Player!");
                return;
            }

            if (CompareTag("Ammo"))
            {
                player.AddAmmo(10);
                Debug.Log("Item Ammo picked up!");
            }
            else if (CompareTag("MedBox"))
            {
                player.Heal(10);
                Debug.Log("Item Health picked up!");
            }

            Destroy(gameObject);
            return;
        }
        else if (other.CompareTag("Enemy") && CompareTag("MedBox"))
        {
            ReactiveEnemy enemy = other.GetComponent<ReactiveEnemy>();
            if (enemy == null)
            {
                Debug.LogError("ReactiveEnemy component not found on Enemy!");
                return;
            }

            enemy.Heal(10);
            Debug.Log("Enemy healed!");

            Destroy(gameObject);
            return;
        }
    }
}
