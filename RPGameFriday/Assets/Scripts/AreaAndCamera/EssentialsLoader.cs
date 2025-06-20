using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject UIScreen;
    public GameObject player;
    public GameObject gameMan;
    public GameObject AudioMan;
    public GameObject battleManager;

    // Start is called before the first frame update
    void Start()
    {
        if(UIFade.instance == null)
        {
          UIFade.instance =  Instantiate(UIScreen).GetComponent<UIFade>();
        }

        if(PlayerController.instance == null)
        {
            PlayerController clone = Instantiate(player).GetComponent<PlayerController>();
            PlayerController.instance = clone;
        }
        if(GameManager.instance == null)
        {
            Instantiate(gameMan);
        }
        if(AudioManager.instance == null)
        {
            Instantiate(AudioMan);
        }
        if(BattleManager.instance == null)
        {
            Instantiate(battleManager);
        }
        
    }
    // battle manager


    // Update is called once per frame
    void Update()
    {
        
    }
}
