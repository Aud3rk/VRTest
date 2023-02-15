using System;
using System.Collections;
using System.Collections.Generic;
using HurricaneVR.Framework.Components;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Lumin;
using Zenject;

public class Bomb : HVRDamageHandlerBase
{
    private float _health=25;
    private float _attackDistance = 0.5f;
    private float _damage = 30;
    private TimerController _timerController;
    private PlayerData _playerData;

    public void Initialize(PlayerData playerData, TimerController timerController)
    {
        _timerController = timerController;
        _playerData = playerData;
    }

    public override void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
            Death();
    }
    private void Update()
    {
        SearchForPlayer();
    }
    private void SearchForPlayer()
    {
        if (Vector3.Distance(transform.position, _playerData.transform.position) < _attackDistance)
        {
            Attack();
        }
    }
    private void Attack()
    {
        _playerData.TakeDamage(_damage);
        Death();
    }
    private void Death()
    {
        Destroy(this.gameObject);
    }
    private void OnDestroy()
    {
        _timerController.pauseMenu -= Death;
    }

}
