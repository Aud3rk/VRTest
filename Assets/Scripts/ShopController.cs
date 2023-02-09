using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class ShopController : MonoBehaviour
{
    private StatisticsController _statisticsController;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private int priceGrenade=100;
    [SerializeField] private int pricePistol=500;
    [Inject]
    public void Construct(StatisticsController statisticsController)
    {
        _statisticsController = statisticsController;
    }

    public void BuyGrenade(GameObject gun)
    {
        if (_statisticsController.gold >= priceGrenade)
        {
            _statisticsController.UpdateGold(-priceGrenade);
            Instantiate<GameObject>(gun, new Vector3(spawnPosition.position.x,spawnPosition.position.y+1,spawnPosition.position.z),Quaternion.identity,null);
        }
    }
    public void BuyPistol(GameObject gun)
    {
        if (_statisticsController.gold >= pricePistol)
        {
            _statisticsController.UpdateGold(-pricePistol);
            Instantiate<GameObject>(gun, new Vector3(spawnPosition.position.x,spawnPosition.position.y+1,spawnPosition.position.z),Quaternion.identity,null);
        }
    }
}
