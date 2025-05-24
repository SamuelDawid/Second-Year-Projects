using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLeaderBoard : MonoBehaviour
{
    public Text first;
    public Text second;
    public Text third;
    public Text fourth;

    private void Awake()
    {
        LeaderBoard.Reset();
    }

    private void LateUpdate()
    {
        List<string> places = LeaderBoard.GetPlaces();

        if (places.Count > 0)
            first.text = "1st: " + places[0];
        if (places.Count > 1)
            second.text = "2nd: " + places[1];
        if (places.Count > 2)
            third.text = "3rd: " + places[2];
        if (places.Count > 3)
            fourth.text = "4th: " + places[3];
    }
}
