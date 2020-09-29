using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healt : MonoBehaviour
{
    [SerializeField] float health = 100f;
   [SerializeField] GameObject explosion;
    int getLife;

    public void Damage(float damage)
    {
        health -= damage;
         if(health <= 0)
        {
          GameObject death = Instantiate(explosion, transform.position, Quaternion.identity)  as  GameObject;
            Destroy(death, 1f);
            Destroy(gameObject);
            if (GetComponent<Attacker>())
            {
                getLife = GetComponent<Attacker>().GetLife();
                FindObjectOfType<HealthDisplay>().GetHealth(getLife);
            }
        }
    }
}
