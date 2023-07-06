using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Player _car;

    void Update()
    {
        _car.SyncPositionToSphere(transform);
        transform.position += _car.HealthBarOffset;
    }
}