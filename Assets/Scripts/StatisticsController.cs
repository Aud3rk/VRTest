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

    public void UpdateStatistic(int enemy, int gold, int wave)
    {
        enemyDead.text = "Enemy dead: " + enemy;
        goldText.text = "Gold: " + gold;
        waveText.text = "Wave: " + wave;
    }
    
}
