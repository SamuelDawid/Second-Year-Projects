using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Stats playerStats;
    public static GameManager instance;
    public string[] itemsHeld;
    public int[] numberOfItems;
    public Items[] referenceItems;
   
   
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveData()
    {
        PlayerPrefs.SetFloat("Player_Position_x", CharacterMovement.instance.transform.position.x);
        PlayerPrefs.SetFloat("Player_Position_y", CharacterMovement.instance.transform.position.y);
        PlayerPrefs.SetFloat("Player_Position_z", CharacterMovement.instance.transform.position.z);
        PlayerPrefs.SetString("Current_Scene", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("Player_" + playerStats + "_Level", playerStats.playerLevel);
        PlayerPrefs.SetInt("Player_" + playerStats + "_currentEXP", playerStats.currentEXP);
        PlayerPrefs.SetInt("Player_" + playerStats + "_currentHP", playerStats.currentHP);
        PlayerPrefs.SetInt("Player_" + playerStats + "_currentMP", playerStats.currentMP);
        PlayerPrefs.SetInt("Player_" + playerStats + "_maxHp", playerStats.maxHp);
        PlayerPrefs.SetInt("Player_" + playerStats + "_maxMP", playerStats.maxMP);
        PlayerPrefs.SetInt("Player_" + playerStats + "_strenght", playerStats.strenght);
        PlayerPrefs.SetInt("Player_" + playerStats + "_defence", playerStats.defence);
        PlayerPrefs.SetInt("Player_" + playerStats + "_wpnPower", playerStats.wpnPower);
        PlayerPrefs.SetInt("Player_" + playerStats + "_armrPower", playerStats.armrPower);

        for (int i = 0; i < itemsHeld.Length; i++)
        {
            PlayerPrefs.SetString("ItemInInventory_" + i, itemsHeld[i]);
            PlayerPrefs.SetInt("ItemAmmount_" + i, numberOfItems[i]);
        }
    }
    public void LoadData()
    {
        CharacterMovement.instance.transform.position = new Vector3(PlayerPrefs.GetFloat("Player_Position_x"), PlayerPrefs.GetFloat("Player_Position_y"), PlayerPrefs.GetFloat("Player_Position_z"));
        PlayerPrefs.GetInt("Player_" + playerStats + "_Level", playerStats.playerLevel);
        PlayerPrefs.GetInt("Player_" + playerStats + "_currentEXP", playerStats.currentEXP);
        PlayerPrefs.GetInt("Player_" + playerStats + "_currentHP", playerStats.currentHP);
        PlayerPrefs.GetInt("Player_" + playerStats + "_currentMP", playerStats.currentMP);
        PlayerPrefs.GetInt("Player_" + playerStats + "_maxMP", playerStats.maxHp);
        PlayerPrefs.GetInt("Player_" + playerStats + "_strenght", playerStats.maxMP);
        PlayerPrefs.GetInt("Player_" + playerStats + "_defence", playerStats.strenght);
        PlayerPrefs.GetInt("Player_" + playerStats + "_wpnPower", playerStats.defence);
        PlayerPrefs.GetInt("Player_" + playerStats + "_armrPower", playerStats.wpnPower);

        for (int i = 0; i < itemsHeld.Length; i++)
        {
            itemsHeld[i] = PlayerPrefs.GetString("ItemInInventory_" + i);
            numberOfItems[i] = PlayerPrefs.GetInt("ItemAmmount_" + i);
        }
    }
    public Items GetItemDetails(string itemToGrab)
    {
        for (int i = 0; i < referenceItems.Length; i++)
        {
            if (referenceItems[i].itemName == itemToGrab)
            {
                return referenceItems[i];
            }
        }
        // return empty item
        return null;
    }
    public void SortItems()
    {
        bool itemAfterSpace = true;

        while (itemAfterSpace)
        {
            itemAfterSpace = false;
            for (int i = 0; i < itemsHeld.Length - 1; i++)
            {
                if (itemsHeld[i] == "")
                {
                    itemsHeld[i] = itemsHeld[i + 1];
                    itemsHeld[i + 1] = "";

                    numberOfItems[i] = numberOfItems[i + 1];
                    numberOfItems[i + 1] = 0;

                    if (itemsHeld[i] != "")
                    {
                        itemAfterSpace = true; // check if the item was moved, repete

                    }
                }
            }
        }

    }
    public void AddItem(string itemToAdd)
    {
        int newItemPosition = 0;
        bool foundSpace = false;

        for (int i = 0; i < itemsHeld.Length; i++)
        {
            if (itemsHeld[i] == "" || itemsHeld[i] == itemToAdd)
            {
                newItemPosition = i;
                i = itemsHeld.Length;
                foundSpace = true;
            }
        }

        if (foundSpace)
        {
            bool itemExist = false;

            for (int i = 0; i < referenceItems.Length; i++)
            {
                if (referenceItems[i].itemName == itemToAdd)
                {
                    itemExist = true;
                    i = referenceItems.Length;
                }

            }
            if (itemExist)
            {
                itemsHeld[newItemPosition] = itemToAdd;
                numberOfItems[newItemPosition]++;
            }
            else
            {
                Debug.LogError(itemToAdd + " Does not exist!!");
            }
        }
        GameMenu.instance.ShowItems();

    }

    public void RemoveItem(string itemToRemove)
    {
        bool foundItem = false;
        int itemPosition = 0;

        for (int i = 0; i < itemsHeld.Length; i++)
        {
            if (itemsHeld[i] == itemToRemove)
            {
                foundItem = true;
                itemPosition = i;

                i = itemsHeld.Length;

            }
        }
        if (foundItem)
        {
            numberOfItems[itemPosition]--;

            if (numberOfItems[itemPosition] <= 0)
            {
                itemsHeld[itemPosition] = "";
            }

            GameMenu.instance.ShowItems();
        }
        else
        {
            Debug.LogError("Couldn not find " + itemToRemove);
        }
    }
}
