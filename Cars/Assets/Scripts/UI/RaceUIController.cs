using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceUIController : MonoBehaviour
{
    [SerializeField] private GameObject leaderboard;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private Text winScreenTitle;

    public void ShowLeaderboard(bool option)
    {
        leaderboard.SetActive(option);
    }
    public void ShowWinScreen(bool option, bool win)
    {
        if (win)
            winScreenTitle.text = "Race Over!";

        else
            winScreenTitle.text = "Race Over";
            winScreen.SetActive(option);
    }

   
}
