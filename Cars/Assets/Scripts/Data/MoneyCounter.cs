﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{
    public Text playercounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playercounter.text = MoneyData.moneyPlayer.ToString();
    }
}
