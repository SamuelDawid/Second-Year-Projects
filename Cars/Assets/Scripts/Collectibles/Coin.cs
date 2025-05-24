using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item, ICurrency, IUsable
{
    public int value = 5;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 180.0f * Time.deltaTime, 0.0f);       
    }

    public void Use(IModifyStats character)
    {
        character.addCoin(MoneyData.moneyPlayer += value);

        Destroy(gameObject);
    }

}
