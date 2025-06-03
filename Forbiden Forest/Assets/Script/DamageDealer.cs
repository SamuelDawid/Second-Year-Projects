using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    
    public float attackCooldown;
    public int attackSpeed;
    public float damage = 100;
    public Transform target;
    private void Start()
    {
       
    }
    public void Update()
    {
        attackCooldown -= Time.deltaTime;
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= 10)
        {
           if(attackCooldown <= 0f)
            {
                Stats.instance.TakeDamage(50);
                attackCooldown = 5;
            }
           
        }
    }
  
}


