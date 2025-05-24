using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidCollisions : MonoBehaviour
{
    [SerializeField] private float avoidLength = 2.0f;
    [HideInInspector] public Vector3 target;

    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.tag == "car")
            target = Vector3.zero;

        else if (other.gameObject.tag == "obstacle")
                 target = Vector3.zero;
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "car")
            target = (transform.position - other.gameObject.transform.position) * avoidLength;

        else if (other.gameObject.tag == "obctacle")
            target = (transform.position - other.gameObject.transform.position) * avoidLength;

    }
}

