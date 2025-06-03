using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string npcName;
    public DiialogManager diialogManager;
    public List<string> npcCon = new List<string>();


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            diialogManager.StartDialog(npcName, npcCon);
        }
    }
}
