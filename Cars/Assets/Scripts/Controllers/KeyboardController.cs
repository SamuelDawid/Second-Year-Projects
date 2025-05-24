using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    [Header("Key Controller")]

    [SerializeField]
    KeyCode pickUp = KeyCode.E;

    [SerializeField]
    KeyCode drop = KeyCode.R;

    [SerializeField]
    KeyCode use = KeyCode.U;

    [Header("Controllable character script")]

    [SerializeField]
    MonoBehaviour target;
    IControllable controlledCharacter;


    // Start is called before the first frame update
    void Start()
    {
        controlledCharacter = target as IControllable;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(pickUp)) controlledCharacter.PickUp();
        if (Input.GetKey(drop)) controlledCharacter.Drop();
        if (Input.GetKey(use)) controlledCharacter.Use();
    }
}
