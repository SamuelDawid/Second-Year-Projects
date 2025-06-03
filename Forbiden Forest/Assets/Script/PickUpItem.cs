using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private bool canPickUp;

    // Update is called once per frame
    void Update()
    {
        if(canPickUp && Input.GetButtonDown("Fire1"))
        {
            GameManager.instance.AddItem(GetComponent<Items>().itemName);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canPickUp = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canPickUp = false;
        }
    }
}
