using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Enemy Car;

    private Rigidbody Body;

    private bool Driving;

    public void StartMotor()
    {
        Driving = true;
    }

    public void StopMotor()
    {
        Driving = false;
    }
    private void Awake()
    {
        Body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Body.maxAngularVelocity = Car.MaxSpeed;

        if (Driving)
            Body.AddTorque(-Car.Steering.transform.right * Car.Acceleration);
    }
}
