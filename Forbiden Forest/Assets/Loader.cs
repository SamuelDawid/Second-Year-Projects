using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
 
    public GameObject audioManager;
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance == null)
        {
            Instantiate(gameManager);

        }
        if (AudioManager.instance == null)
        {
            Instantiate(audioManager);
        }
    }
}
