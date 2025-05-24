using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{

    float lastActivity = 0.0f;
    [SerializeField] int hazardValue;

    // Start is called before the first frame update
    void Start()
    {
        lastActivity = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1.0f);

        foreach (var col in colliders)
        {
            IModifyStats damageableObject = col.GetComponent<IModifyStats>();

             if (damageableObject != null && Time.time > lastActivity + 0.1f)
             
            {
                damageableObject.addHealth(-hazardValue);
                lastActivity = Time.time;
            }
        }
    }

}
