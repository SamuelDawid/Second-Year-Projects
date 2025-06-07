using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTips : MonoBehaviour
{
    public GameObject TipWindow;
    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            TipWindow.SetActive(true);
           
        }

    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            Destroy(gameObject);
        }
    }
   

}
