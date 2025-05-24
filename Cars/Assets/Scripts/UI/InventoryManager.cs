using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour 
{
    [SerializeField] public Canvas myCanvas;

    [SerializeField] public Component myContent;

    [Header("Inventory")]

    public List<Item> pickedItems = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        Refresh();
    }

    public void Add(Item item)
    {
        pickedItems.Add(item);
        Refresh();
    }

    public Item GetLast()
    {
        Item lastItem = pickedItems[pickedItems.Count - 1];
        pickedItems.RemoveAt(pickedItems.Count - 1);
        Refresh();
        return lastItem;
    }

    public bool IsEmpty()
    {
        return pickedItems.Count == 0;
    }

    void Refresh()
    {
        // Remove everything
        foreach (Transform child in myContent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        for (var i = 0; i < pickedItems.Count; ++i)
        {
            GameObject newObj = new GameObject();
            Image newImage = newObj.AddComponent<Image>();
            newImage.sprite = pickedItems[i].GetIcon();
            newObj.GetComponent<RectTransform>().SetParent(myContent.transform);
            newObj.SetActive(true);
        }
    }
}
