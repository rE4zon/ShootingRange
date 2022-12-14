using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float maxHealth;
    [SerializeField] GameObject healthBarUI;
    [SerializeField] Slider slider;

    private void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
    }
    private void Update()
    {
        slider.value = CalculateHealth();

        if(health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        if(health <= 0)
        {
            Destroy(gameObject);
        }    
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }
    float CalculateHealth()
    {
        return health / maxHealth;
    }
}
