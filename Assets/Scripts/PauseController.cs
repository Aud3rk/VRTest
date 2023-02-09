using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PauseController : MonoBehaviour
{
    [Inject] private PlayerData _playerData;
    [Inject] private TimerController _timerController;
    [SerializeField] private GameObject shop;
    private void Awake()
    {
        _timerController.pauseMenu += InitPause;
        _timerController.spawnNewWave += EndPause;
        shop.SetActive(false);
    }
    private void InitPause()
    {
        shop.SetActive(true);
        _playerData.ResetHealth();
    }
    private void EndPause()
    {
        shop.SetActive(false);
    }
    private void OnDestroy()
    {
        _timerController.pauseMenu -= InitPause;
        _timerController.spawnNewWave -= EndPause;
    }
}
