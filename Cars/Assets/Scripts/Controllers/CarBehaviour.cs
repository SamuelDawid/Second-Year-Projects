using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CarBehaviour : MonoBehaviour, IDrivable
{
    [Header("References")]
    public WheelCollider[] WheelColliders;
    public GameObject[] Wheels;
    public Rigidbody rb;
    public GameObject brakeLight;

    [Header("Drive")]
    public float torque = 200;
    public float maxSteerAngle = 30;
    public float maxBrakeTorque = 500;
    public int maxSpeed = 200;
    public float currentSpeed { get { return rb.velocity.magnitude; } }
    public float currentAngle;

    public float steerSpeed = 0.1f;

    public float downForce = 3;

    public int carNumber;
    public Action<double> MHP;

    [Header("Flip car")]
    public float lastTimeChecked;

    public void Awake()
    {
        // Set up center of gravity to increase car stability
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -1f, 0);
    }

    public void Drive(float accel, float steer, float brake)
    {
        // Get Drive() values
        accel = Mathf.Clamp(accel, -1, 1);
        steer = Mathf.Clamp(steer, -1, 1) * maxSteerAngle;
        brake = Mathf.Clamp(brake, 0, 1) * maxBrakeTorque;

        if (brake != 0)
            brakeLight.SetActive(true);
         else
            brakeLight.SetActive(false);

        float thrustTorque = 0;
        if (currentSpeed < maxSpeed)
            thrustTorque = accel * torque;

        currentAngle = steer;

        // Calculate each wheel
        for (int i = 0; i < 4; i++)
        {
            WheelColliders[i].motorTorque = thrustTorque;
            if (i < 2)
            {
                // Simple Ackermann steering geometry
                // (Improves steering and increases stability)
                float thisAngle = 0;
                if (currentAngle < 0)
                {
                    if (i == 0)
                        thisAngle = (currentAngle / 2);
                    else
                        thisAngle = currentAngle;
                }
                else
                {
                    if (i == 0)
                        thisAngle = currentAngle;
                    else
                        thisAngle = (currentAngle / 2);
                }

                WheelColliders[i].steerAngle = thisAngle;
                Wheels[i].transform.localEulerAngles = new Vector3(0, thisAngle, 0);
            }
            else
            {
                WheelColliders[i].steerAngle = 0;
                WheelColliders[i].brakeTorque = brake;
            }
        }
    }

    public void FixedUpdate()
    {
        // Add downward force to simulate drag
        // (Increases stability)
        rb.AddForce(Vector3.down * downForce, ForceMode.Acceleration);

        //speed of the cars, calculating m/h
        double mhp = rb.velocity.magnitude * 2.237;
        mhp = Math.Round(mhp, 0);
        MHP?.Invoke(mhp);
    }

    public void FlipCar()
    {
        if (transform.up.y > 0.5f || rb.velocity.magnitude > 1)
        {
            lastTimeChecked = Time.time;
        }

        if (Time.time > lastTimeChecked + 2) //if car is upsidedown for 2 sek this will fix it
        {
            transform.position += Vector3.up;
            transform.rotation = Quaternion.LookRotation(this.transform.forward);
        }
    }

  
}

