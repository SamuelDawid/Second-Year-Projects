using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    bool isMouseDragging;
    bool isMouseZooming;

    IDraggable target;
    Vector3 screenPosition;
    Vector3 offset;

    Vector3 currentMousePos;
    Vector3 lastMousePos;

    Camera myCamera;

    // Start is called before the first frame update
    void Start()
    {
        currentMousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
        lastMousePos = currentMousePos;

        // myCamera = Camera.main;
        myCamera = Camera.allCameras[0];
    }

    // Update is called once per frame
    void Update()
    {
        bool leftMouseButtonDown = Input.GetMouseButtonDown(0);
        bool rightMouseButtonDown = Input.GetMouseButtonDown(1);

        bool leftMouseButtonUp = Input.GetMouseButtonUp(0);
        bool rightMouseButtonUp = Input.GetMouseButtonUp(1);

        if (leftMouseButtonDown || rightMouseButtonDown)
        {
             Debug.Log("button pressed");

            RaycastHit hitInfo;
            target = ReturnClickedObject(out hitInfo);

            if (target != null)
            {
                

                screenPosition = myCamera.WorldToScreenPoint(target.GetPosition());

                if (leftMouseButtonDown)
                {
                    isMouseDragging = true;
                    isMouseZooming = false;

                    offset = target.GetPosition() - myCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));

                    target.StartControl();
                    Debug.Log("hit cube!");
                }
                else if (rightMouseButtonDown)
                {
                    isMouseDragging = false;
                    isMouseZooming = true;

                    Vector3 mousePos = myCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
                    offset = target.GetPosition() - new Vector3(mousePos.x, 0.0f, mousePos.y);

                    target.StartControl();
                }


            }
        }

        if (target != null)
        {
            lastMousePos = currentMousePos;
            currentMousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
            Vector3 posDiff = currentMousePos - lastMousePos;
            Vector3 hPosDiff = new Vector3(posDiff.x, posDiff.z, posDiff.y);

            if (leftMouseButtonUp)
            {
                target.SetVelocity(posDiff);
                target.EndControl();
                isMouseDragging = false;
            }
            if (rightMouseButtonUp)
            {
                target.SetVelocity(hPosDiff);
                target.EndControl();
                isMouseZooming = false;
            }

            if (isMouseDragging)
            {
                Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);

                Vector3 currentPosition = myCamera.ScreenToWorldPoint(currentScreenSpace) + offset;

                target.SetPosition(currentPosition);
            }
            else if (isMouseZooming)
            {
                Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);

                Vector3 mousePos = myCamera.ScreenToWorldPoint(currentScreenSpace);
                Vector3 currentPosition = new Vector3(mousePos.x, 0.0f, mousePos.y) + offset;

                target.SetPosition(currentPosition);
            }
        }
    }

    IDraggable ReturnClickedObject(out RaycastHit hit)
    {
        // test
        // Debug.Log(Camera.allCamerasCount);

        IDraggable targetObject = null;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            targetObject = hit.collider.gameObject.GetComponent<IDraggable>();
        }
        return targetObject;
    }


}
