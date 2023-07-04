using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Acceleration;
    [SerializeField] private float MaxSpeed;
    [SerializeField] private float MaxReverseSpeed;

    [SerializeField] private Transform MeshTransform;

    private Rigidbody Body;

    private void Start()
    {
        Body = GetComponent<Rigidbody>();

        Body.maxAngularVelocity = MaxSpeed;
    }

    private void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");

        Body.maxAngularVelocity = MaxSpeed;

        if (moveVertical < 0)
            Body.maxAngularVelocity = MaxReverseSpeed;

        Body.AddTorque(MeshTransform.forward * moveVertical * Acceleration);
    }
}
