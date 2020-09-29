using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float damage = 50f;
    [SerializeField] float Speed = 1f;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * Speed, Space.World);

    }

    public void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Healt>();
        if (health != null)
        {
            health.Damage(damage);
            Destroy(gameObject);
        }
    }

}


//collision zucc, enemy,destroy projectile,script getdamage, death, destroy enemy,