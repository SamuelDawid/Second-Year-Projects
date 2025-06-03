using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [Header("Items Type")]
    public bool isItem;
    public bool isWeapon;
    

    public string itemName, description;
    [Header("Items Value")]
    public int value;

    public Sprite itemSprite;
    [Header("Items Details")]
    public int ammountToChange;
    public bool affectHP, affectMP, affectStr,isSword, isWand;
    public int weponStr;
    public static Items instance;
    Stats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void Use( )
    {
        Stats player = GameManager.instance.playerStats;
        if(isItem)
        {
            if(affectHP)
            {
                player.currentHP += ammountToChange;
            }
        }
        if(affectMP)
        {
            player.currentMP += ammountToChange;
        }
        if(isWeapon)
        {
            if(affectStr && isWand)
            {
                isWand = true;
                player.strenght += ammountToChange;
                Stats.instance.Wand.SetActive(true);
            }
            else if( affectStr && isSword)
            {
                isSword = true;
                player.strenght += ammountToChange;
                Stats.instance.Sword.SetActive(true);
            }
        }

        GameManager.instance.RemoveItem(itemName);
    }
}
