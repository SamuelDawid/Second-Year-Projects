using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameUIController : MonoBehaviour
{
    public Text playerName;
    public Transform target;


    void Start()
    {

        this.transform.SetParent(GameObject.Find("Canvas").GetComponent<Transform>(), false);
        playerName = this.GetComponent<Text>();
    
    }

    void LateUpdate()
    {
        this.transform.position = Camera.main.WorldToScreenPoint(target.position + Vector3.up * 1.2f);
   
    }
}
