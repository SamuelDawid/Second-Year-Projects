using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ExpBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxExp(int maxExp)
    {
        slider.maxValue = maxExp;
        slider.value = Stats.instance.currentEXP;
    }
    public void SetExp(int maxExp)
    {
        slider.value = maxExp;
    }
}
