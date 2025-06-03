using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject theMenu;
    public GameObject Menu, inventoryMenu, OptionsMenu, Quest, deadMenu;
    private Stats playerStats;
    public TextMeshProUGUI hpText, mpText, lvlText, expText, strText, defText,ArmorText, wpnText;
    public ItemButton[] itemButtons;
    public Items activeItem;
    public Image wpn;
    public Slider expSlider;
    public float maxExp;
    public static GameMenu instance;
    public TextMeshProUGUI  useButtonText, goldText;
    public GameObject Quest1, Quest2, Quest3, Quest4, Quest5, Quest6;
    public TextMeshProUGUI Quest1text, Quest2text, Quest3text, Quest4text, Quest5text, Quest6text;
    // public TextMeshProUGUI itemCharChoiceName;
    public GameObject itemCharChoiceMenu;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        UpdateStatusChar();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStatusChar();
        if(QManager.instance.questMarkersComplete[0])
        {
            Stats.instance.eqWand();
            Quest1text.text = "Compleate";
        }
        if (QManager.instance.questMarkersComplete[1])
        {
            Quest2text.text = "Compleate";
        }
        if (QManager.instance.questMarkersComplete[2])
        {
            Quest3text.text = "Compleate";
        }
        if (QManager.instance.questMarkersComplete[3])
        {
            Stats.instance.equipSword();
            Quest4text.text = "Compleate";
        }
        if (QManager.instance.questMarkersComplete[4])
        {
            Quest5text.text = "Compleate";
        }
        if (QManager.instance.questMarkersComplete[5])
        {
            Quest6text.text = "Compleate";
        }
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        OptionsMenu.SetActive(false);
    }
    public void MainMenu()
    {

    }
    public void Quit()
    {
        Application.Quit();
    }

    public void UpdateStatusChar()
    {
        playerStats = GameManager.instance.playerStats;
        hpText.text = playerStats.currentHP.ToString();
        mpText.text = playerStats.currentMP.ToString();
        lvlText.text = playerStats.currentEXP.ToString();
        strText.text = playerStats.strenght.ToString();
        ArmorText.text = playerStats.armrPower.ToString();
        wpnText.text = playerStats.wpnPower.ToString();
        expSlider.value = playerStats.currentEXP;
      
}
    
    public void OpenMenu()
    {
        UpdateStatusChar();
        Menu.gameObject.SetActive(!Menu.gameObject.activeSelf);

    }
    public void OpeninventoryMenu()
    {

        inventoryMenu.gameObject.SetActive(!inventoryMenu.gameObject.activeSelf);

    }
    public void OpenOptionsMenu()
    {
        Time.timeScale = 0f;
        OptionsMenu.gameObject.SetActive(!OptionsMenu.gameObject.activeSelf);

    }
    public void OpenQuest()
    {

        Quest.gameObject.SetActive(!Quest.gameObject.activeSelf);

       
    }
    public void SaveGame()
    {
        GameManager.instance.SaveData();
        QManager.instance.SaveQuestData();

    }
    public void BacktoMain()
    {
        SceneManager.LoadScene("MainMenu");
        AudioManager.instance.PlayBGM(1);
    }

    public void ShowItems()
    {
        GameManager.instance.SortItems();
        for (int i = 0; i < itemButtons.Length; i++)
        {
            itemButtons[i].buttonValue = i;

            if (GameManager.instance.itemsHeld[i] != "")
            {
                itemButtons[i].ButtonImage.gameObject.SetActive(true);
                itemButtons[i].ButtonImage.sprite = GameManager.instance.GetItemDetails(GameManager.instance.itemsHeld[i]).itemSprite;
                itemButtons[i].amountText.text = GameManager.instance.numberOfItems[i].ToString();
            }
            else
            {
                itemButtons[i].ButtonImage.gameObject.SetActive(false);
                itemButtons[i].amountText.text = "";
            }
        }
    }

    public void SelectItem(Items newItem)
    {
        activeItem = newItem;
        if (activeItem.isItem)
        {
            useButtonText.text = "Use";
        }

    }

    public void DiscardItem()
    {
        if (activeItem != null)
        {
            GameManager.instance.RemoveItem(activeItem.itemName);
        }


    }
    public void UseItem()
    {
        activeItem.Use();
    }
    public void ClosemenuQuest1()
    {
        Quest1.SetActive(!Quest1.gameObject.activeSelf);
    }
    public void ClosemenuQuest2()
    {
        Quest2.SetActive(!Quest2.gameObject.activeSelf);
    }
    public void ClosemenuQuest3()
    {
        Quest3.SetActive(!Quest3.gameObject.activeSelf);
        AudioManager.instance.PlaySFX(2);
    }
    public void ClosemenuQuest4()
    {
        Quest4.SetActive(!Quest4.gameObject.activeSelf);
    }
    public void ClosemenuQuest5()
    {
        Quest5.SetActive(!Quest5.gameObject.activeSelf);
    }
    public void ClosemenuQuest6()
    {
        Quest6.SetActive(!Quest6.gameObject.activeSelf);
    }

    public void Dead()
    {
        Time.timeScale = 0f;
        deadMenu.SetActive(true);
        AudioManager.instance.PlaySFX(0);
    }
}
