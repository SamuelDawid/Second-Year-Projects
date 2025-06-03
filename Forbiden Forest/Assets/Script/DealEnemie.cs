using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealEnemie : MonoBehaviour
{
    //Need chanege

    public float attackCooldown;
    public int attackSpeed;
    public int damage;
    private void Start()
    {
        damage = Stats.instance.strenght * Stats.instance.wpnPower;
    }
    public void Update()
    {
 
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.gameObject.GetComponent<HealthSystem>().TakeDamage(damage);
        }
    }

}
