using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    CanvasGroup canvasGroup;
    float HUDsetting = 0;

    CheckpointsController cpController;
   // public Text playerName;

    int carRego;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = this.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;

        if (PlayerPrefs.HasKey("HUD"))
        HUDsetting = PlayerPrefs.GetFloat("HUD");

    }

    // Update is called once per frame
    void Update()
    {
        if (RaceController.racing)
            canvasGroup.alpha = 1;
            //canvasGroup.alpha = HUDsetting;

        if (Input.GetKeyDown(KeyCode.H)) //press H to show and hide HUD elements 
        {
            canvasGroup.alpha = canvasGroup.alpha == 1 ? 0 : 1;
            HUDsetting = canvasGroup.alpha;
            PlayerPrefs.SetFloat("HUD", canvasGroup.alpha);
        }
    }

}
