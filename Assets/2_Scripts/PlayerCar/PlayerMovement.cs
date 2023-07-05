using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Player _car; 

    private void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");

        _car.SphereRigidbody.maxAngularVelocity = _car.MaxSpeed;

        if (moveVertical < 0)
            _car.SphereRigidbody.maxAngularVelocity = _car.MaxReverseSpeed;

        _car.SphereRigidbody.AddTorque(-_car.Steering.transform.right * moveVertical * _car.Acceleration);
    }
}
