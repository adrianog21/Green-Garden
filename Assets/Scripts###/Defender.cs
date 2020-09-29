using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;

    public void AddStars(int amountStars)
    {
        FindObjectOfType<StarDisplay>().AddStars(amountStars);
    }

    public int GetStarCost()
    {
        return starCost;
    }

}
