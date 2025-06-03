using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public Animator anim;
    public float currenthealth;
    public int damage;
    public static HealthSystem instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
      
        if (currenthealth <= 0)
        {
            anim.SetTrigger("isDead");
            StartCoroutine(Dead());
        }
    }
    

    public void TakeDamage(int ammount)
    {
        currenthealth -= ammount;
    }
   
    public IEnumerator Dead()
    {
        
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }



}
