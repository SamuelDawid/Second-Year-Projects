using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IModifyStats
{
    void addHealth(int healthAmount);

    void addCoin(int value);

    void addSpeed(int speedAmount);

}
