using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider mSlider;

    public void SetMaxMana(int mana)
    {
        mSlider.maxValue = mana;
        mSlider.value = mana;
    }
    public void SetMana(int mana)
    {
        mSlider.value = mana;
    }
}
