using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtCollider : MonoBehaviour
{
    int damage;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject attacker = collision.gameObject;
        if(attacker.GetComponent<Attacker>())
        {
            damage = attacker.GetComponent<Attacker>().LifeDamage();
            FindObjectOfType<HealthDisplay>().LoseHealth(damage);
            Destroy(attacker);
        }
    }
}
