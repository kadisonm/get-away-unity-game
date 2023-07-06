using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySyncMesh : MonoBehaviour
{
    [SerializeField] private Enemy _car;

    void Update()
    {
        _car.SyncPositionToSphere(transform);

        transform.localRotation = Quaternion.Euler(_car.Steering.transform.localEulerAngles.x, _car.Steering.transform.localEulerAngles.y, _car.Steering.transform.localEulerAngles.z);
    }
}
