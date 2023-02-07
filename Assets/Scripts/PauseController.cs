using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PauseController : MonoBehaviour
{
    [Inject] private PlayerData _playerData;
    [SerializeField] private GameObject shop;
    private void Awake()
    {
        TimerController.pauseMenu += InitPause;
        TimerController.spawnNewWave += EndPause;
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
        TimerController.pauseMenu -= InitPause;
        TimerController.spawnNewWave -= InitPause;
    }
}
