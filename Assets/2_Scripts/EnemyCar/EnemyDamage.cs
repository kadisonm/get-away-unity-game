using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private Enemy _car;

    public int GetDamage()
    {
        return _car.Damage;
    }
}
