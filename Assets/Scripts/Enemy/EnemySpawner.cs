using System;
using System.Collections;
using System.Collections.Generic;
using Installers;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [Inject] private TimerController _timerController;
    [Inject] private PlayerData _playerData;
    [Inject] private StatisticsController _statisticsController;

    private void Awake()
    {
        _timerController.spawnNewWave += Spawn;
    }
    private void Spawn()
    {
        for(int i=0;i<_statisticsController.waveNumber;i++)
        {
            GameObject enemy=Instantiate(enemyPrefab, this.transform);
            enemy.GetComponent<Enemy>().Initialize(_playerData,_timerController);
            _timerController.AddEnemyToList(enemy);
        }
    }
    private void OnDestroy()
    {
        _timerController.spawnNewWave -= Spawn;
    }
}
