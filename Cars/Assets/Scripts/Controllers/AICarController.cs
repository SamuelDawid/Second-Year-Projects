using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICarController : CarBehaviour
{
    [Header("References")]
    private AvoidCollisions avoidCollisions;
    private CarBehaviour cb;
    private Vector3 target;
    public WPoints wp;
    private Vector3[] wayPoints;

    [Header("Stering")]
    public float steeringSensitivity = 0.1f;
    public float pathSmoothingDistance;
    private int currentWayPoint = 0;

    private Vector3 avoidCollisionsTarget;

    [Header("Sensors")]
    public float sensorLenght = 5f;
    public float frontSensorPosition = 0.5f;

    public Transform startpos;


    private void Awake()
    {
        // Get references
        cb = GetComponent<CarBehaviour>();
        rb = GetComponent<Rigidbody>();
        avoidCollisions = GetComponent<AvoidCollisions>();

        avoidCollisionsTarget = Vector3.zero;
    }

    private void Start()
    {
        // Get checkpoints
        GameObject[] checkpoints = FindObjectOfType<CheckpointContainer>().checkpoints;
        wayPoints = new Vector3[checkpoints.Length];
        for (int i = 0; i < checkpoints.Length; i++)
            wayPoints[i] = checkpoints[i].transform.position;
        currentWayPoint = 0;

        // Register car
        carNumber = LeaderBoard.RegisterCar(name);

    }

    void Update()
    {
        if (RaceController.racing)
        {
            DriveAI();
            FlipCar();
        }
    }

    void DriveAI()
    {
        // Avoid collisions
        if (avoidCollisions)
            avoidCollisionsTarget = avoidCollisions.target;

        // Calculate target
        target = wayPoints[currentWayPoint] + avoidCollisionsTarget;
        float distanceToTarget = Vector3.Distance(target, cb.rb.gameObject.transform.position);
        if (distanceToTarget < pathSmoothingDistance)
        {
            currentWayPoint++;
            currentWayPoint %= wayPoints.Length;
        }

        target = wayPoints[currentWayPoint] + avoidCollisionsTarget;

        // Calculate angle to target
        float targetAngle = Vector2.SignedAngle(new Vector2(transform.forward.x, transform.forward.z),
        new Vector2(target.x, target.z) - new Vector2(transform.position.x, transform.position.z));

        // Get Drive() values 
        float steer = Mathf.Clamp(-(targetAngle / 10), -maxSteerAngle, maxSteerAngle);
        float accel = 400f;
        float brake = 0.30f;

        // Slow down and brake a little if turning sharply at speed
        if (Mathf.Abs(targetAngle) < (maxSteerAngle / 1.25f) || rb.velocity.magnitude < 10)
        {
            accel = 500f;
            brake = 0f;
        }

        cb.Drive(accel, steer, brake);
    }

    // Gizmo for showing the car's target
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(target + avoidCollisionsTarget, (pathSmoothingDistance / 2));
        Gizmos.DrawLine(transform.position, target + avoidCollisionsTarget);
    }

  
   

}
