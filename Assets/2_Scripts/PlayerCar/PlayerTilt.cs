using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTilt : MonoBehaviour
{
    [SerializeField] private float TiltAmount;
    [SerializeField] private float MaxTiltThreshold;
    [SerializeField] private GameObject Steering;

    [SerializeField] private Transform Sphere;
    [SerializeField] private Rigidbody SphereRigidbody;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * TiltAmount;

        if (transform.position != Sphere.position)
            transform.position = Sphere.position;

        float sphereVelocity = Mathf.Clamp(SphereRigidbody.velocity.magnitude, 0, MaxTiltThreshold);
        float rotationMultiplier = sphereVelocity / MaxTiltThreshold;

        transform.localRotation = Quaternion.Euler(moveHorizontal * rotationMultiplier, Steering.transform.localEulerAngles.y, Steering.transform.localEulerAngles.z);
    }
}
