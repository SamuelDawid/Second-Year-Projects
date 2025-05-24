using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public GameObject endGameScreen;
    private bool endGame = false;

    // Start is called before the first frame update
    void Start()
    {
        endGame = false;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals ("endRace"))
        {
            endGame = true;
            Time.timeScale = 0f;
            endGameScreen.SetActive(true);
        }
    }

    
}
