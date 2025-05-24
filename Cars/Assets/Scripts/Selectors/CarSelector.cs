using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CarSelector : MonoBehaviour
{
    private GameObject[] carList;

    private int index;


    // Start is called before the first frame update
    void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        
        carList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++, Input.GetKey(KeyCode.RightArrow))
            carList[i] = transform.GetChild(i).gameObject;

        //Toggle off the render
        foreach (GameObject go in carList)
            go.SetActive(false);

        //Toggle on the selected character
        if (carList[index])
            carList[index].SetActive(true);
    }

    public void ToggleLeft()
    {

        //Toggle off the current character
        carList[index].SetActive(false);

        index--;
        if (index < 0)
            index = carList.Length - 1;
        Input.GetKey(KeyCode.LeftArrow);

        //Toggle on the new character
        carList[index].SetActive(true);

    }


    public void ToggleRight()
    {
        //Toggle off the current character
        carList[index].SetActive(false);

        index++;
        if (index == carList.Length)
            index = 0;

        //Toggle on the new character
        carList[index].SetActive(true);
    }

    public void SelectButton()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Track1");
      //  SelectionData.isPlayer1true = true;
    }

}
