using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] carPrefabs;
    public CameraController[] cameraControllers;

    void Start()
    {
        int selectedCar = PlayerPrefs.GetInt("CharacterSelected");
        GameObject newCar = Instantiate(carPrefabs[selectedCar]);
        newCar.transform.position = spawnPoint.position;
        newCar.transform.rotation = spawnPoint.rotation;

        foreach (CameraController cameraController in cameraControllers)
            cameraController.target = newCar.transform;
    }
}
