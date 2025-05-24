using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceController : MonoBehaviour
{
    public GameObject[] countdownItems;
    public static bool racing = false;


  //  [SerializeField] TMPro.TextMeshProUGUI mhpText;

    [SerializeField] TMPro.TextMeshProUGUI timerText;
    public float totalTime;


    // Start is called before the first frame update
    void Start()
    {
        racing = false;

        foreach (GameObject g in countdownItems)
        {
            g.SetActive(false);
        }

        StartRace();
    }

    public void StartRace()
    {

        StartCoroutine(PlayCountDown());
    }

    // Update is called once per frame
    void Update()
    {

        Timer();
     
    }

    IEnumerator PlayCountDown()
    {

        yield return new WaitForSeconds(2);
        foreach (GameObject g in countdownItems)
        {

            g.SetActive(true);
            yield return new WaitForSeconds(1);
            g.SetActive(false);
        }

        racing = true;

    }

    public void ShowMHP(double mhp)
    {
  //      mhpText.text = mhp + " MHP";
    }

    public void Timer()
    {
        if (racing == true)
               
        {
            totalTime += Time.deltaTime;
            int minutes = (int)totalTime / 60;
            int seconds = (int)totalTime % 60;

            timerText.text = string.Format("Race time {0} : {1} ", minutes.ToString("00"), seconds.ToString("00"));
        }
        
    }

    
}


