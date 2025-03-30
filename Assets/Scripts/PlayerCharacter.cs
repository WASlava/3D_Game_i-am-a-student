using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private int maxAmmo = 30;
    [SerializeField] private int currentAmmo;
    [SerializeField] private float currentHealth;

    //PlayerUI playerUI;

    public Slider healthBar;
    public Image fillImage;
    public TextMeshProUGUI ammoText;

    public void UpdateHealth(float health)
    {
        float healthPercent = health / 100;
        healthBar.value = healthPercent;
        //healthBar.value = health;
        fillImage.color = Color.Lerp(Color.red, Color.green, healthPercent);
    }

    public void UpdateAmmo(int ammo, int maxAmmo)
    {
        ammoText.text = $"Ammo: {ammo}/{maxAmmo}";
        //currentAmmo = ammo;
    }
    public void AddAmmo(int amount)
    {
        Debug.Log($"Ammo picked up! {amount}  Current Ammo: {currentAmmo}");
        currentAmmo = Mathf.Min(currentAmmo + amount, maxAmmo);
        UpdateAmmo(currentAmmo, maxAmmo);
        Debug.Log($"Ammo picked up! Current Ammo: {currentAmmo}");
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        UpdateHealth(currentHealth);
        Debug.Log("Healed! Current Health: " + currentHealth);
    }

    public bool Shoot()
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;
            UpdateAmmo(currentAmmo, maxAmmo);
            return true;
        }
        else
        {
            Debug.Log("No ammo left!");
            return false;
        }
    }

    void Start()
    {
        currentHealth = maxHealth;
        currentAmmo = maxAmmo;

            UpdateHealth(currentHealth);
            UpdateAmmo(currentAmmo, maxAmmo);
 
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealth(currentHealth);
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
        UpdateHealth(currentHealth);
        Debug.Log("Гравець відродився!");
    }
}
