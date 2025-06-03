using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Transform firePoint;
    public Rigidbody projectilePrefab;
    public Rigidbody projectilePrefab1;
    public float lunchForce = 300;
    public bool isWaiting, isWaitinga;
    public int dyley;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(!isWaiting)
            {
                StartCoroutine(ShootFire());
            }
           
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(!isWaitinga)
            {
                StartCoroutine(Frostbolt());
            }
          
        }
    }
  
    public IEnumerator ShootFire()
    {
        
       var projectileInstance = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectileInstance.AddForce(firePoint.forward * lunchForce);
        isWaiting = true;
        
        yield return new WaitForSeconds(dyley);
        isWaiting = false;
    }
    public IEnumerator Frostbolt()
    {
        var projectileInstance = Instantiate(projectilePrefab1, firePoint.position, firePoint.rotation);
        projectileInstance.AddForce(firePoint.forward * lunchForce);
        isWaitinga = true;
        yield return new WaitForSeconds(dyley);
        isWaitinga = false;
    }

    }

