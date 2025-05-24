using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsController : MonoBehaviour
{
    [Header("References")] 
    private PlayerCarController playerCarController;
    private AICarController aiCarController;
    private CarBehaviour carBehaviour;
    public GameObject lastCheckPoint;

    [Header("Variables")]
    public int lap = 0;
    public int checkPoint = -1;
    private int checkPointCount;
    private int nextCheckPoint = 1;
    public float timeEntered = 0;
    private bool isPlayer;
    private bool isAI;
    

    void Start()
    {
        isPlayer = GetComponent<PlayerCarController>();
        isAI = GetComponent<AICarController>();

        GameObject[] cps = GameObject.FindGameObjectsWithTag("checkpoint");
        checkPointCount = cps.Length;
        foreach (GameObject c in cps)
        {
            if (c.name == "0")
            {
                lastCheckPoint = c;
                checkPoint = 0;
                nextCheckPoint = 1;
                break;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "checkpoint")
            HandleCheckpoint(col.gameObject);
    }

    private void HandleCheckpoint(GameObject checkpointObject)
    {
        int thisCPNumber = int.Parse(checkpointObject.name);

        if (thisCPNumber == nextCheckPoint)
        {
            if (!carBehaviour)
                carBehaviour = GetComponent<CarBehaviour>();
            if (carBehaviour)
                LeaderBoard.SetPosition(carBehaviour.carNumber, lap, checkPoint, timeEntered);

            lastCheckPoint = checkpointObject;
            checkPoint = thisCPNumber;
            timeEntered = Time.time;
            if (checkPoint == 0 && isPlayer) 
                FinishLap();

            if (checkPoint == 0 && isAI)
                FinishLap();

            nextCheckPoint++;
            if (nextCheckPoint >= checkPointCount)
                nextCheckPoint = 0;
        }
    }

    private void FinishLap()
    {
        Debug.Log("Finishing lap");
        lap++;

        // If the player crosses the line display the end of race display
        // If I want more laps - assign a variable to the GameController and check if laps > the variable

        if (isPlayer)
        {
            if (!playerCarController)
                playerCarController = GetComponent<PlayerCarController>();
            string firstPlace = LeaderBoard.GetPlaces()[0];
            bool win = (firstPlace == playerCarController.name);
            FindObjectOfType<RaceUIController>().ShowWinScreen(true, win);
            RaceController.racing = false;
        }

        else if (isAI)
        {
            if (!aiCarController)
                aiCarController = GetComponent<AICarController>();
            string firstPlace = LeaderBoard.GetPlaces()[0];
            bool win = (firstPlace == aiCarController.name);
            FindObjectOfType<RaceUIController>().ShowWinScreen(true, win);
            RaceController.racing = false;
        }

    }
}
