using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Player _car;

    void LateUpdate()
    {
        _car.SyncPositionToSphere(transform);

        transform.position += _car.CameraOffset;
    }
}
