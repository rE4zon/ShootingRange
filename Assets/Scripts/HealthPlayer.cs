using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    public int Health;
    [SerializeField] Slider slider;
    void Start()
    {
        
    }

    
    void Update()
    {
        slider.value = Health;
    }
}
