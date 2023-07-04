using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    [SerializeField] Vector3 Offset;

    void LateUpdate()
    {
        transform.position = Target.position + Offset;
    }
}
