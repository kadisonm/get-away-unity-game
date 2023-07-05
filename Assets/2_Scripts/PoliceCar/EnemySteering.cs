using UnityEngine;

public class EnemySteering : MonoBehaviour
{
    [SerializeField] private Enemy _car;

    private Vector3 _targetRotation;

    public void LookTowards(Vector3 pos)
    {
        _targetRotation = pos;
    }

    private void Start()
    {
        _targetRotation = Vector3.zero;
    }

    private void Update()
    {
        _car.SyncPositionToSphere(transform);

        Vector3 direction = (transform.position - _targetRotation).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);

        lookRotation.x = 0;
        lookRotation.z = 0;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, _car.RotationSpeed * Time.deltaTime);
    }
}
