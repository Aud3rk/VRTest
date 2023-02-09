using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TimerController : MonoInstaller
{
    [Inject] private StatisticsController _statisticsController;
    [SerializeField] private GameObject buttonOnStart;
    
    public Action spawnNewWave;
    public Action pauseMenu;
    
    private List<GameObject> enemyList;
    public override void InstallBindings()
    {
        Container.Bind<TimerController>().FromInstance(this).AsSingle();
    }
    private void Start()
    {
        enemyList = new List<GameObject>();
        buttonOnStart.SetActive(false);
        StartGame();
    }
    public void InvokeSpawn()
    {
        spawnNewWave.Invoke();
        buttonOnStart.SetActive(false);
    }
    public void InvokePause()
    {
        pauseMenu.Invoke();
        buttonOnStart.SetActive(true);
        _statisticsController.UpdateWaveNumber();
    }

    public void StartGame()
    {
        new WaitForSeconds(5f);
        InvokeSpawn();
    }
    public void DeathEnemy(GameObject enemy)
    {
        enemyList.Remove(enemy);
        _statisticsController.UpdateGold(40);
        _statisticsController.UpdateEnemyDeadCount();
        PauseCheck();
    }
    private void PauseCheck()
    {
        if (enemyList.Count == 0)
        {
            InvokePause();
        }
    }
    public void AddEnemyToList(GameObject enemy)
    {
        enemyList.Add(enemy);
    }
    
}
