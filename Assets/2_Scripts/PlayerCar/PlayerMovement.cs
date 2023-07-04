using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Player Car; 

    private Rigidbody Body;

    private void Awake()
    {
        Body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");

        Body.maxAngularVelocity = Car.MaxSpeed;

        if (moveVertical < 0)
            Body.maxAngularVelocity = Car.MaxReverseSpeed;

        Body.AddTorque(Car.Steering.transform.forward * moveVertical * Car.Acceleration);
    }
}
