using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    [SerializeField] int speedAmount;
    float lastActivity = 0.0f;

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

           // if (damageableObject != null )

            if (damageableObject != null && Time.time > lastActivity)

            {
                damageableObject.addSpeed(speedAmount);
                lastActivity = Time.time;

                Debug.Log("SpeedUp");
            }
        }
    }

   
}
