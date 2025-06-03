using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingEnemis : MonoBehaviour
{
    public Transform player;
     public Animator anim;
    public int attackDistance, runDistance, speed;
    public static StandingEnemis instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        //  anim = GetComponent<Animator>();
            }

    // Update is called once per frame
    void Update()
    {
       
        //float angle = Vector3.Angle(direction, this.transform.forward);
        if (Vector3.Distance(player.position, this.transform.position) < runDistance)
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), speed);

            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", true);
            if (direction.magnitude > attackDistance)
            {
                // need ajustment
                this.transform.Translate(0, 0, 0.05f);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
            }else
            {
               
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
            }
          
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
        }
       
     
    }
  

}
