using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraChanger : MonoBehaviour
{
   public Camera cam1; //normal view
   public Camera cam2; //top view
   public Camera cam3; //rare view 

    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z) && (cam1.enabled == true || cam3.enabled == true))
        {
            cam1.enabled = false;
            cam2.enabled = true;
            cam3.enabled = false;

            Debug.Log("normal view");
        }
        
        

        else if (Input.GetKeyDown(KeyCode.X) && (cam2.enabled == true || cam1.enabled == true))
        {
            cam1.enabled = false;
            cam2.enabled = false;
            cam3.enabled = true;

            Debug.Log("top view");
        }

        else if (Input.GetKeyDown(KeyCode.C) && (cam2.enabled == true || cam3.enabled == true))
        {
            cam1.enabled = true;
            cam2.enabled = false;
            cam3.enabled = false;

            Debug.Log("rare view");

        }
    }

}
