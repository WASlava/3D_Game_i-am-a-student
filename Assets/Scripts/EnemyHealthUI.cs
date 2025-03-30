using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField] private GameObject healthEnemyPrefab; // Префаб індикатора
    private Slider healthSlider;
    private Image fillImage;
    private Transform cameraTransform;

    public Color fullHealthColor = Color.green;
    //public Color zeroHealthColor = Color.red;

    private GameObject healthBarInstance;

    public void Initialize(int maxHealth)
    {
        if (healthEnemyPrefab == null)
        {
            Debug.LogError("Health bar prefab not assigned!");
            return;
        }

        healthBarInstance = Instantiate(healthEnemyPrefab, transform.position + Vector3.up * 2f, Quaternion.identity);
        healthSlider = healthBarInstance.GetComponentInChildren<Slider>();
        fillImage = healthSlider.fillRect.GetComponent<Image>();

        healthBarInstance.transform.SetParent(transform);
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;

        Camera activeCamera = GameObject.FindWithTag("Player")?.GetComponentInChildren<Camera>();
        if (activeCamera != null)
        {
            cameraTransform = activeCamera.transform;
        }
    }

    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        if (healthSlider != null)
        {
            //float healthPercent = (float)currentHealth / maxHealth;
            healthSlider.value = currentHealth;
            //healthSlider.value = healthPercent * healthSlider.maxValue;
            //fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, healthPercent);
        }
    }

    void Update()
    {
        if (cameraTransform != null && healthBarInstance != null)
        {
            healthBarInstance.transform.LookAt(cameraTransform);
            healthBarInstance.transform.Rotate(0, 180, 0);
        }
    }

    public void DestroyHealthBar()
    {
        if (healthBarInstance != null)
        {
            Destroy(healthBarInstance);
        }
    }
}
