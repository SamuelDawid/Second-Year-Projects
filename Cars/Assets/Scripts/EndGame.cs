using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    public GameObject gameObject;
    

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag.Equals ("Player"))
        {
            Time.timeScale = 0f;
            gameObject.SetActive(true);
            

        }
    }
}
