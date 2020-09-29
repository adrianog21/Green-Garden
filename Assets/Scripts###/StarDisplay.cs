﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text starText;

    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public void AddStars(int enemyStars)
    {
        stars += enemyStars;
        UpdateDisplay();
    }

    public void SpendStars(int amountStars)
    {
        if (amountStars <= stars)
        {
            stars -= amountStars;
            UpdateDisplay();
        }
    }

    public int GetStars()
    {
        return stars;
    }
}

