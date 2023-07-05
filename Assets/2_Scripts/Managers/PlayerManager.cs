using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    public int PlayerHealth;
    [SerializeField] int PlayerMaxHealth;
    public int PlayerMoney { get; private set; }

    public void DamagePlayer(int amount)
    {
        PlayerHealth = Mathf.Clamp(PlayerHealth - amount, 0, PlayerMaxHealth);

        if (PlayerHealth <= 0)
        {
            GameManager.Instance.EndRound();
        }
    }

    public void AddRoundMoney(int money)
    {
        PlayerMoney += money;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }
}
