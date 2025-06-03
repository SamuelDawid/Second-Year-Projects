using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    public string questToMark;
    public bool QuestComplete;

    public bool markOnEnter;
    private bool Mark;

    public bool deactivateOnMarking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mark && Input.GetButtonDown("Fire1"))
        {
            Mark = false;
            MarkQuest();
        }
    }
     public void MarkQuest()
    {
        if(QuestComplete)
        {
            QManager.instance.MarkQuestComplete(questToMark);
           
        }
        else
        {
            QManager.instance.MarkQuestIncomplete(questToMark);
        }

        gameObject.SetActive(!deactivateOnMarking);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(markOnEnter )
            {
                MarkQuest();
                
            }
            else
            {
                Mark = true;
            }
            

        }
    }
    private void OnTriggerEexit(Collider other)
    {
        if (other.tag == "Player")
        {

            Mark = false;

        }
    }
}
