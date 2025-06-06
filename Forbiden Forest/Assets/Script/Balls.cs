﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    public float lifetime = 2f;
    private float lifeTimer;

    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer -= Time.deltaTime;
        if(lifeTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
