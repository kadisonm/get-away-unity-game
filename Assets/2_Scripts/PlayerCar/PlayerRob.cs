using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRob : MonoBehaviour
{
    [SerializeField] private Player _car;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (GameObject building in MapManager.Instance.InstantiatedHeists)
            {
                float distance = (_car.Sphere.transform.position - building.transform.position).magnitude;

                if (distance <= _car.ActivationDistance)
                {
                    float earnedMoney = building.GetComponent<Heist>().RobPlace();

                    GameManager.Instance.CollectedRoundMoney += (int) earnedMoney;
                }
            }
        } 
    }
}
