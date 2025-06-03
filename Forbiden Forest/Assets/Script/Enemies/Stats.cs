using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int strenght, defence, wpnPower, armrPower;
    public int maxHp = 150;
    public int maxMP = 50;
    public int currentHP, currentMP;
    public bool hasDied;
    public int[] expToNextLevel;
    public int[] mpLvLBonus;
    public int maxLevel = 100;
    public int baseEXP = 1000;
    public int playerLevel = 1;
    public int currentEXP;
    public HealthBar healthBar;
    public ExpBar expBar;
    public ManaBar manaBar;
    public static Stats instance;
    public string charName;
    public GameObject Sword, Wand;
    public bool isPlayer;
    
    void Start()
    {
        instance = this;
        isPlayer = true;
        currentMP = maxMP;
        currentHP = maxHp;
        healthBar.SetMaxHealth(maxHp);
        manaBar.SetMaxMana(maxMP);
       
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseEXP;

        for (int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
        }
    }
    private void Update()
    {
        if(currentHP <= 0)
        {
            GameMenu.instance.Dead();
        }
        if(Input.GetKeyUp(KeyCode.K))
        {
            AddExp(100);
        }
    }
   
    public void equipSword()
    {
        Sword.gameObject.SetActive(true);
    }
    public void eqWand()
    {
        Wand.gameObject.SetActive(true);
    }
    public void AddExp(int expToAdd)
    {
        currentEXP += expToAdd;
        // checking exp and level
        if (playerLevel < maxLevel)
        {
            while (currentEXP >= expToNextLevel[playerLevel])
            {
                currentEXP -= expToNextLevel[playerLevel];

                playerLevel++;

                // even or odd adding stats
                if (playerLevel % 2 == 0)
                {
                    strenght++;

                }
                else
                {

                    defence++;
                }

                maxHp = Mathf.FloorToInt(maxHp * 1.05f);
                currentHP = maxHp;
                // changing with level MP

                currentMP = maxMP;

            }
        }
        if (playerLevel >= maxLevel)
        {
            currentEXP = 0;
        }
    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        healthBar.SetHealth(currentHP);
    }
    void SpendMana(int ammount)
    {
        currentMP -= ammount;
        manaBar.SetMana(currentMP);
    }
 
  
}
