using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"Гравець отримав урон! Здоров'я: {currentHealth}");

        if (currentHealth <= 0)
        {
            Debug.Log("Гравець загинув!");
            Respawn();
        }
    }

    private void Respawn()
    {
        currentHealth = maxHealth; 
        Debug.Log("Гравець відродився!");
    }
}
