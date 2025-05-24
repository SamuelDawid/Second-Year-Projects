using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public enum CameraType { Front, Main, Tracking, Map };
    public CameraType cameraType;

    [SerializeField] private Vector3 offset;

    [SerializeField] public Transform target;
    [SerializeField] private bool fixedPosition;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float rotationSpeed;

    private void FixedUpdate()
    {
        HandleTranslation();
        HandleRotation();
    }

    private void HandleTranslation()
    {
        switch (cameraType)
        {
            case CameraType.Front:
                transform.position = target.TransformPoint(offset);
                break;
            case CameraType.Main:
            case CameraType.Tracking:
                Vector3 targetPosition = target.TransformPoint(offset);
                transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
                break;
            case CameraType.Map:
                transform.position = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
                break;


        }
    }

    private void HandleRotation()
    {
        switch (cameraType)
        {
            case CameraType.Front:
                transform.rotation = target.rotation;
                break;
            case CameraType.Main:
            case CameraType.Tracking:
            case CameraType.Map:
                Vector3 direction = target.position - transform.position;
                Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
                break;
        }
    }
}
