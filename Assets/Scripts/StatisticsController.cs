using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class StatisticsController : MonoBehaviour
{
    [SerializeField] private TMP_Text enemyDead;
    [SerializeField] private TMP_Text goldText;
    [SerializeField] private TMP_Text waveText;

    public int gold { get; private set; }
    public int enemyDeadCount { get; private set; }
    public int waveNumber { get; private set; }

    private void Start()
    {
        gold = 0;
        enemyDeadCount = 0;
        waveNumber = 1;
        UpdateAllStats();
    }

    public void UpdateGold(int temp)
    {
        gold += temp;
        goldText.text = "Gold: " + gold;
    }
    public void UpdateEnemyDeadCount()
    {
        enemyDeadCount++;
        enemyDead.text = "Enemy dead: " + enemyDeadCount;
    }    
    public void UpdateWaveNumber()
    {
        waveNumber++;
        waveText.text = "Wave: " + waveNumber;
    }

    private void UpdateAllStats()
    {
        goldText.text = "Gold: " + gold;
        enemyDead.text = "Enemy dead: " + enemyDeadCount;
        waveText.text = "Wave: " + waveNumber;
    }
}
