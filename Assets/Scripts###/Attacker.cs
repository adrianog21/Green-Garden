using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] int lifeDamage;
    [SerializeField] int getLife;
    float walkSpeed = 0f;
    GameObject currentTarget;


    private void Awake()
    {
        FindObjectOfType<levelController>().EnemiesSpawned();
    }

    private void OnDestroy()
    {
        levelController level = FindObjectOfType<levelController>();
        if(level != null)
        {
            level.Enemiesdeath();
        }
    }

    void Update()
    {
        
        transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }

    public void  SetMovementSpeed(float speed)
    {
        walkSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if  (!currentTarget) { return; }
        Healt health = currentTarget.GetComponent<Healt>();
        if (health)
        {
            health.Damage(damage);
        }      

    }
    public int GetLife() { return getLife; }
    public int LifeDamage() { return lifeDamage; }
}


