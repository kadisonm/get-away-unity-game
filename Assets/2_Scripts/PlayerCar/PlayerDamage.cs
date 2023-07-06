using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private Player _car;

    private float _timer;
    private bool _canDamage;

    private void Awake()
    {
        _canDamage = false;
    }

    private void Update()
    {
        if (_canDamage == false && _timer < _car.ImmunityTime)
        {
            _timer += Time.deltaTime;
            _canDamage = false;

            return;
        }

        _timer = 0;
        _canDamage = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_canDamage && collision.gameObject.tag == "Enemy")
        {
            EnemyDamage damage = collision.gameObject.GetComponent<EnemyDamage>();

            if (damage)
            {
                _canDamage = false;
                _car.Health.DamagePlayer(damage.GetDamage());
            }
        }
    }
}
