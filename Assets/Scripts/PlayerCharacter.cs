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
        Debug.Log($"������� ������� ����! ������'�: {currentHealth}");

        if (currentHealth <= 0)
        {
            Debug.Log("������� �������!");
            Respawn();
        }
    }

    private void Respawn()
    {
        currentHealth = maxHealth; 
        Debug.Log("������� ���������!");
    }
}
