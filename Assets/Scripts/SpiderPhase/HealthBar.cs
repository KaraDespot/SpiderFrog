using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarSprite;

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        _healthBarSprite.fillAmount = currentHealth / maxHealth;
    }
}