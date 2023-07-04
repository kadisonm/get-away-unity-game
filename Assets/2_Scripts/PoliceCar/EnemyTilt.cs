using UnityEngine;

public class EnemyTilt : MonoBehaviour
{
    [SerializeField] private Enemy Car;

    void Update()
    {
        Car.SyncPositionToSphere(transform);

        transform.localRotation = Quaternion.Euler(Car.SteerObject.transform.localEulerAngles.x, Car.SteerObject.transform.localEulerAngles.y, Car.SteerObject.transform.localEulerAngles.z);
    }
}
