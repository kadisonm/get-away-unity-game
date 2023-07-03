using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Acceleration;
    [SerializeField] private float RotationSpeed;
    [SerializeField] private float MaxSpeed;

    private Rigidbody Body;

    private void Start()
    {
        Body = GetComponent<Rigidbody>();
    }

    //private void Update()
    //{
    //    float moveHorizontal = Input.GetAxis("Horizontal");
    //    float moveVertical = Input.GetAxis("Vertical");

    //    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
    //    movement = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * movement.normalized;

    //    transform.position += MoveSpeed * Time.deltaTime * movement;
    //}

    private void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 forceDirection = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * Vector3.forward;
        Body.AddTorque(transform.up * moveHorizontal * RotationSpeed, ForceMode.Acceleration);

        //if (Body.velocity != Vector3.zero)
        //{
        //    transform.Rotate(0f, moveHorizontal * RotationSpeed, 0f);
        //}

        if (Body.velocity.magnitude < MaxSpeed)
        { 
            Vector3 movement = transform.forward * (moveVertical * Acceleration);
            Body.AddForce(movement, ForceMode.Acceleration);

            Debug.Log("Moving");
        }    
    }
}
