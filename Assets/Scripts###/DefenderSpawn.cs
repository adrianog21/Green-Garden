using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawn : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defender";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent() // per creare un ogetto parent dove far  spawnare tutti i child
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if(!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefender(GetSquareClick());
        //  chiama il metodo spawn richiamando getSquare per avere  gridPos
    }

    public void SetSelectedDefender(Defender selectedDefender)
    {
        defender = selectedDefender;
    }

    private void AttemptToPlaceDefender(Vector2 gridPos)
    {
        var StarDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();
        int stars = StarDisplay.GetStars();
        if(defenderCost <= stars)
        {
            Defender newDefender = Instantiate(defender, gridPos, Quaternion.identity) as Defender;
            newDefender.transform.parent = defenderParent.transform;  // per rendere newdefender un child di defender
            StarDisplay.SpendStars(defenderCost);

        }
    }

    private Vector2 GetSquareClick()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapGrid(mousePos);
        return gridPos;
        //clicpos è la posizione del mouse in coordinate
        // e mousepos transforma le coordinate in una posizione dello schermo
        //gridPos = mousePos che viene  trasformato in int destro SnapGrid
    }


    private Vector2 SnapGrid(Vector2 rawWorldPos)
    {
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        return new Vector2(newX, newY);
        //questa funzione  serve per cambiare le  coordinate del mouse
        // da float a int per una distanza uguale tra gli squawn
    }

 /*   public void spawnDefender(Vector2 worldPos) // world pos = gridPos
    {
        //Metodo che chiede un vettore worldpos perinstanciate
        Defender newDefender = Instantiate(defender, worldPos, Quaternion.identity) as Defender;
        Debug.Log("Click");
        
    } */
}
/*  questo script serve a far  spawnare un defender
 *  per farlo spawnare in griglia si prende prima le coordinate del mouse quando lo clicki
 *  poi trasformi le coordinate in un punto dello schermo
 *  poiche la posizione è in float spownerebbero un po' a caso
 *  quindi si cambia la posizione di x e y da float a int così avranno una distanza uguale
 *  nella griglia*/