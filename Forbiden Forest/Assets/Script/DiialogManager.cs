using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiialogManager : MonoBehaviour
{
    public GameObject dialogPanel;
    public TextMeshProUGUI npcNameText, dialogtext;
    private List<string> conversiation;
    private int convIndex;

    private void Start()
    {
        dialogPanel.SetActive(false);
    }
    public void StartDialog(string _npcName, List<string> _conversation)
    {
        npcNameText.text = _npcName;
        conversiation = new List<string>(_conversation);
        dialogPanel.SetActive(true);
        convIndex = 0;
        ShowText();

    }

    public void StopDialog()
    {
        dialogPanel.SetActive(false);
    }
    public void ShowText()
    {
        dialogtext.text = conversiation[convIndex];
    }
    public void NextL()
    {
        if(convIndex < conversiation.Count - 1)
        convIndex += 1;
        ShowText();
    }
   
}
