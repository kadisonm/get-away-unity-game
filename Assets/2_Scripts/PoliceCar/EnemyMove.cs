using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Enemy _car;

    private void FixedUpdate()
    {
        _car.SphereRigidbody.maxAngularVelocity = _car.MaxSpeed;

        _car.SphereRigidbody.AddTorque(-_car.Steering.transform.right * _car.Acceleration);
    }
}
