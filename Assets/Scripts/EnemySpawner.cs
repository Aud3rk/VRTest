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

    private void Awake()
    {
        TimerController.spawnNewWave += Spawn;
    }
    private void Spawn()
    {
        for(int i=0;i<_playerData.waveNumber;i++)
        {
            GameObject enemy=Instantiate(enemyPrefab, this.transform);
            enemy.GetComponent<Enemy>().Initialize(_playerData,_timerController);
            _timerController.enemyList.Add(enemy);
        }
    }
    private void OnDestroy()
    {
        TimerController.spawnNewWave -= Spawn;
    }
}
