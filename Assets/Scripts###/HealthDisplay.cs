using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] loadingLevel level;
    [SerializeField] float baseLives = 6;
    float health;
    Text healthText;
    float gameDifficulty;


    // Start is called before the first frame update
    void Start()
    {
        gameDifficulty = PlayerPrefsController.GetDifficulty();
        health = baseLives - gameDifficulty;
        healthText = GetComponent<Text>();
        UpdateDisplay();
        Debug.Log(gameDifficulty);
    }

    private void UpdateDisplay()
    {
        healthText.text = health.ToString();
    }
    

    public void LoseHealth(int damage)
    {
        health -= damage;
        UpdateDisplay();
        if(health  <= 0)
        {
            FindObjectOfType<levelController>().GameOver();
        }
    }

    public void GetHealth(int life)
    {
        health += life;
        UpdateDisplay();
    }
     
    public void SetDifficulty(float difficulty)
    {
        gameDifficulty = difficulty;
        
    }
}
