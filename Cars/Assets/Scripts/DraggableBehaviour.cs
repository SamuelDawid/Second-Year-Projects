using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableBehaviour : MonoBehaviour, IDraggable
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartControl()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        if (rb)
        {
            rb.isKinematic = true;
        }
    }

    public void EndControl()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        if (rb)
        {
            rb.isKinematic = false;
        }
    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetVelocity(Vector3 vel)
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        if (rb)
        {
            rb.velocity = vel;
        }
    }
}
