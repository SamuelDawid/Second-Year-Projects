using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public States states;
    public GameObject opponent;

    public int attackRad, currentWP, moveSpeed, rotationSpeed, distance, follwoingDis;
    bool isAttacking;
    public GameObject[] waypoints;
    GameObject NPC;
    Animator myAnim;

    private void Start()
    {
        myAnim = GetComponent<Animator>();
        NPC = myAnim.gameObject;
       

    }
    public GameObject GetPlayer()
    {
        return opponent;
    }
    private void Awake()
    {
        
    }
    private void Update()
    {

        myAnim.SetFloat("distance", Vector3.Distance(transform.position, opponent.transform.position));
        if (Vector3.Distance(opponent.transform.position, transform.position) < follwoingDis && !isAttacking)
        {
            
            states = States.Follow;
            
        }
        else
        {
            
            states = States.Patrol;
            
        }
        if (Vector3.Distance(opponent.transform.position, transform.position) <= attackRad)
        {
         
            states = States.Attack;
          
        }
       



        switch (states)
        {
            case States.Patrol:
                {
                    myAnim.SetBool("isWalking", true);
                    myAnim.SetBool("isFollowing", false);
                    myAnim.SetBool("isAttacking", false);
                    if (waypoints.Length == 0) return;
                    if (Vector3.Distance(waypoints[currentWP].transform.position, NPC.transform.position) < distance)
                    {
                        currentWP++;
                        if (currentWP >= waypoints.Length)
                        {
                            currentWP = 0;
                        }
                    }
                    var direction = waypoints[currentWP].transform.position - NPC.transform.position;
                    NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
                    NPC.transform.Translate(0, 0, Time.deltaTime * moveSpeed);
                    break;

                }
            case States.Follow:
                {
                    
                    myAnim.SetBool("isAttacking", false);
                    myAnim.SetBool("isWalking", false);
                    myAnim.SetBool("isFollowing", true);
                    int newSpeed = 5;
                   
                    var direction = opponent.transform.position - NPC.transform.position;
                    NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
                    NPC.transform.Translate(0, 0, Time.deltaTime * newSpeed);
                    
                    break;
                }
            case States.Attack:
                {
                    
                    isAttacking = true;
                    myAnim.SetBool("isAttacking", true);
                    myAnim.SetBool("isWalking", false);
                    myAnim.SetBool("isFollowing", false);
                    break;
                }
        }
    }
   
  
  
}

public enum States
{
    Patrol,
    Follow,
    Attack
}
