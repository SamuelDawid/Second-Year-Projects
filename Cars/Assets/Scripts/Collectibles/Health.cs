using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Item, IUsable
{
    [SerializeField] int healthAmount = 20;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(180.0f * Time.deltaTime, 0.0f, 0.0f);

    }

    public void Use(IModifyStats characterStats)
    {
        characterStats.addHealth(healthAmount);
        Destroy(gameObject);
    }

}
