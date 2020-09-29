using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    SpriteRenderer spriteColor;
    

    private void Start()
    {
        spriteColor = GetComponent<SpriteRenderer>();
        ButtonsCostLabel();
        
    }

    private void ButtonsCostLabel()
    {
        Text costText = GetComponentInChildren<Text>();
        if(!costText)
        {
            Debug.LogError(name + " has no cost text");
        }
        else
        {
            costText.text = defenderPrefab.GetStarCost().ToString(); 
        }
    }

    private void OnMouseDown() // metodo che viene chiamato se viene cliccato il collider di questo ogetto
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton button in buttons)
        {
            button.spriteColor.color = new Color32(75, 75, 75, 255);
        }
        spriteColor.color = Color.white;
        FindObjectOfType<DefenderSpawn>().SetSelectedDefender(defenderPrefab);
    }
}
