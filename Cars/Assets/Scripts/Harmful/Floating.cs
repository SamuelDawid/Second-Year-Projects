using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    float currentTime = 0.0f;
    [SerializeField] float amplitude = 0.0f;

    Vector3 initialPosition;
    public int mode = 0;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    float FunctionChoice(float x)
    {
        if (mode == 0)
        {
            return Mathf.Sin(x * Mathf.PI);
        }

        if (mode == 1)
        {
            return Mathf.Cos(x * Mathf.PI);
        }

        if (mode == 2)
        {
            int modx = (int)(x) % 5;
            return modx;
        }

        if (mode == 3)
        {
            return 6;
        }

        return 0; // default
    }

    // Update is called once per frame
    void Update()
    {
        
        float x = 7.12f;

        transform.position = initialPosition + new Vector3(0.0f, FunctionChoice(currentTime) * amplitude, 0.0f);

        currentTime += Time.deltaTime;
    }


}
