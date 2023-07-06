using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Player _car;

    public void Awake()
    {
        _car.CurrentHealth = _car.PlayerMaxHealth;
    }

    public void DamagePlayer(int amount)
    {
        int newHealth = _car.CurrentHealth - amount;

        _car.CurrentHealth = Mathf.Clamp(newHealth, 0, _car.PlayerMaxHealth);

        if (_car.CurrentHealth <= 0)
            GameManager.Instance.EndRound();
    }
}
