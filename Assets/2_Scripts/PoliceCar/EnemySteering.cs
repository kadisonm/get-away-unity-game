using UnityEngine;

public class EnemySteering : MonoBehaviour
{
    [SerializeField] private Enemy Car;

    private Vector3 TargetRotation;

    public void LookTowards(Vector3 pos)
    {
        TargetRotation = pos;
    }

    private void Awake()
    {
        TargetRotation = Vector3.zero;
    }

    private void Update()
    {
        Car.SyncPositionToSphere(transform);

        Vector3 direction = (transform.position - TargetRotation).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);

        lookRotation.x = 0;
        lookRotation.z = 0;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Car.RotationSpeed * Time.deltaTime);
    }
}
