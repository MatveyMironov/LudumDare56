using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBarFill;
    [SerializeField] private HealthController healthController;

    private void DisplayHealth()
    {
        healthBarFill.fillAmount = (float)healthController.CurrentHealth / healthController.MaxHealth;
    }

    private void OnEnable()
    {
        healthController.OnHealthChanged += DisplayHealth;
    }

    private void OnDisable()
    {
        healthController.OnHealthChanged -= DisplayHealth;
    }
}
