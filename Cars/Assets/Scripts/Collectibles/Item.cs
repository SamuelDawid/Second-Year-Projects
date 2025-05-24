using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IPickable
{
    [SerializeField] Sprite icon;

    public void PickUp()
    {
        gameObject.SetActive(false);
    }

    public void Drop(Vector3 location)
    {
        transform.position = location;
        gameObject.SetActive(true);
    }

    public Sprite GetIcon()
    {
        return icon;
    }
}
