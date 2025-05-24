using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{

    public bool isLeveltrue = false;
    public GameObject moneyMessage;


  
    public void Track1Select()
    {

        SceneManager.LoadScene("Track1");
       // LevelData.LevelStringSelected = "Track1";
        isLeveltrue = true;
    }

    public void Track2Select()
    {
        if (CheckMoney())
        {
            LevelData.LevelStringSelected = "Track2";
            isLeveltrue = true;
        }
        else
        {
            moneyMessage.SetActive(true);
        }
    }


    public void Track3Select()
    {
        if (CheckMoney())
        {
            LevelData.LevelStringSelected = "Track3";
            isLeveltrue = true;
        }
        else
        {
            moneyMessage.SetActive(true);
        }
    }


    public bool CheckMoney()
    {
        if (MoneyData.moneyPlayer >= 50)
        {
            return true;
        }

        return false;

    }

}

