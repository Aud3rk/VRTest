using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class ShopController : MonoBehaviour
{

    private PlayerData _playerData;
    [SerializeField] private StatisticsController statisticsController;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private int priceGrenade=100;
    [SerializeField] private int pricePistol=500;

    [Inject]
    public void Construct(PlayerData playerData)
    {
        _playerData = playerData;
    }

    public void BuyGrenade(GameObject gun)
    {
        if (_playerData.goldCount >= priceGrenade)
        {
            _playerData.goldCount -= priceGrenade;
            Instantiate<GameObject>(gun, new Vector3(spawnPosition.position.x,spawnPosition.position.y+1,spawnPosition.position.z),Quaternion.identity,null);
            statisticsController.UpdateStatistic(_playerData.enemyDeadCount,_playerData.goldCount,_playerData.waveNumber);
        }
    }
    public void BuyPistol(GameObject gun)
    {
        if (_playerData.goldCount >= pricePistol)
        {
            _playerData.goldCount -= pricePistol;
            Instantiate<GameObject>(gun, new Vector3(spawnPosition.position.x,spawnPosition.position.y+1,spawnPosition.position.z),Quaternion.identity,null);
            statisticsController.UpdateStatistic(_playerData.enemyDeadCount,_playerData.goldCount,_playerData.waveNumber);
        }
    }
    
}
