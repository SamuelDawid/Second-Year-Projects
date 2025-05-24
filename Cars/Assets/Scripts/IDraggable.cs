using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDraggable
{
    void StartControl();
    void EndControl();
    void SetPosition(Vector3 pos);
    Vector3 GetPosition();
    void SetVelocity(Vector3 vel);

}
