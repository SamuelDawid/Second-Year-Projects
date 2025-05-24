using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawn : MonoBehaviour
{
   // public List<PickUpTag> ListOfPickups = new List<PickUpTag>();
    public List<Transform> ListOfSpawnPos = new List<Transform>();



    public float startTimeBtwSpawn = 15f;
    public float timeBtwSpawn;


    public int numOfPickupsSpawn = 1;

    // Start is called before the first frame update
    void Start()
    {
        timeBtwSpawn = startTimeBtwSpawn / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    void Timer()
    {
        if (timeBtwSpawn <= 0)
        {
            SpawnPickup(numOfPickupsSpawn);

            timeBtwSpawn = startTimeBtwSpawn;
        }

        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }


    }

    void SpawnPickup(int numOfSpawn)
    {

        for (int i = 0; i < numOfSpawn; i++)
        {


          //  PickUpTag randomPickup = ListOfPickups[Random.Range(0, ListOfPickups.Count)];
            Transform randomPos = ListOfSpawnPos[Random.Range(0, ListOfSpawnPos.Count)];

           // Instantiate(randomPickup, randomPos.position, Quaternion.identity);

        }

    }
}
