using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Target : MonoBehaviour
{
    [SerializeField] float health = 50f;
    [SerializeField] float maxHealth;
    [SerializeField] GameObject healthBarUI;
    [SerializeField] Slider slider;

    private void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }


    public void TakeDamage (float amount)
    {
        slider.value = CalculateHealth();
        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        health -= amount;
        {
            if (health <=0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
