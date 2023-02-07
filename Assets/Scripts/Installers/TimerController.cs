using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TimerController : MonoInstaller
{
    [Inject] private PlayerData _playerData;
    [SerializeField] private StatisticsController _statisticsController;
    [SerializeField] private GameObject buttonOnStart;
    
    public static Action spawnNewWave;
    public static Action pauseMenu;

    
    public List<GameObject> enemyList;
    
    private bool _check = true;
    private float _timerToStart=5f;
    public void InvokeSpawn()
    {
        spawnNewWave.Invoke();
        buttonOnStart.SetActive(false);
    }

    public void InvokePause()
    {
        pauseMenu.Invoke();
        buttonOnStart.SetActive(true);
        _playerData.waveNumber++;
        _statisticsController.UpdateStatistic(_playerData.enemyDeadCount,_playerData.goldCount,_playerData.waveNumber);
    }

    private void Start()
    {
        enemyList = new List<GameObject>();
        _playerData.goldCount = 200;
        buttonOnStart.SetActive(false);
    }

    public override void InstallBindings()
    {
        Container.Bind<TimerController>().FromInstance(this).AsSingle();
    }

    private void Update()
    {
        TimeToStart();
        if(Input.GetKeyDown(KeyCode.C))
            InvokeSpawn();
    }

    private void TimeToStart()
    {
        _timerToStart -= Time.deltaTime;
        if (_timerToStart <= 0&&_check)
        {
            spawnNewWave.Invoke();
            _check = false;
        }
    }

    public void DeathEnemy(GameObject enemy)
    {
        enemyList.Remove(enemy);
        _playerData.goldCount += 40;
        _playerData.enemyDeadCount++;
        _statisticsController.UpdateStatistic(_playerData.enemyDeadCount,_playerData.goldCount,_playerData.waveNumber);
        PauseCheck();
    }

    private void PauseCheck()
    {
        if (enemyList.Count == 0)
        {
            InvokePause();
        }
    }
    
}
