using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCarController : CarBehaviour, IControllable, IModifyStats
{
    [Header("Controllable character script")]

    public GameObject playerNamePrefab;
    public string playerNameText;
    

    [Header("Variables")]

    [SerializeField] InventoryManager inventory;
    float lastDroppedTime = 0.0f;
    [SerializeField] int maxHealth = 100;
    [SerializeField] int minHealth = 0;
    [SerializeField] int health = 100;
    [SerializeField] Component healthBar;

    [SerializeField] int speed = 100;
    [SerializeField] int minSpeed = 0;

   

    void Start()
    {
        brakeLight.SetActive(false);

        // Set up player name
        GameObject playerName = Instantiate(playerNamePrefab);
        playerName.GetComponentInChildren<Text>().text = playerNameText;

        // Register car
        carNumber = LeaderBoard.RegisterCar(name);        

    }

    void Update()
    {
        Steer();
    }

    public void Steer()
    {
        float a = Input.GetAxis("Vertical");
        float s = Input.GetAxis("Horizontal");
        float b = Input.GetAxis("Jump");

        if (!RaceController.racing) a = 0; //start driving after countdown 

        Drive(a, s, b);
    }

    public void PickUp()
    {
        Collider[] coliders = Physics.OverlapSphere(transform.position, 0.1f);

        foreach (var col in coliders)
        {
            IPickable pickableObject = col.GetComponent<IPickable>();

            if (pickableObject != null)
            {

                pickableObject.PickUp();

                Item pickedItem = pickableObject as Item;
                if (pickedItem)

                {
                    inventory.Add(pickedItem);
                }

            }
        }
    }

    public void Drop()
    {
        if (!inventory.IsEmpty() && Time.time > lastDroppedTime + 1.0f)
        {
            IPickable lastItem = inventory.GetLast();
            lastItem.Drop(transform.position);

            lastDroppedTime = Time.time;
        }
    }

    public void Use()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1f);

        foreach (var col in colliders)
        {
            IUsable usableObject = col.GetComponent<IUsable>();

            if (usableObject != null)
            {
                usableObject.Use(this);
            }
        }
    }

    public void updateHealthBar()
    {
        healthBar.transform.localScale = new Vector3((float)(health - minHealth) / (maxHealth - minHealth), 1.0f);
    }

    public void addHealth(int healthAmount)
    {
        health += healthAmount;
        if (health > maxHealth) health = maxHealth;
        if (health < minHealth) health = minHealth;

        updateHealthBar();
    }

    public void updateMoney()
    {
       // MoneyData.moneyPlayer += value;
    }

    public void addCoin(int value)
    {
        //MoneyData.moneyPlayer += value;
    }

    public void addSpeed (int speedAmount)
    {
        speed += speedAmount;
        if (currentSpeed < maxSpeed) speed = maxSpeed;
        if (currentSpeed > maxSpeed) speed = minSpeed;
       
    }

    

}



