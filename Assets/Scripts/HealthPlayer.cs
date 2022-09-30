using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerHPText;
    
    [SerializeField] static int playerHP = 100;
    public static bool isGameOver;
    
    void Start()
    {
        isGameOver = false;
    }

    
    void Update()
    {
        
        playerHPText.text = "+" + playerHP;
        if (isGameOver)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    public static void TakeDamage(int damageAmount)
    {
        playerHP -= damageAmount;
        if (playerHP <= 0)
            isGameOver = true;
    }
}
