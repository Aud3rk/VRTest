using System;
using System.Collections;
using System.Collections.Generic;
using HurricaneVR.Framework.Components;
using UnityEngine;
using UnityEngine.Lumin;
using Zenject;

public class Bomb : HVRDamageHandlerBase
{
    private float _health=25;
    private float _attackDistance = 0.5f;
    private float _damage = 30;
    private PlayerData _player;
    [Inject] private TimerController _timerController;

    public void Initialize(PlayerData player)
    {
        _player = player;
        _timerController.pauseMenu += Death;
    }
    public override void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
            Death();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < _attackDistance)
        {
            _player.TakeDamage(_damage);
            Death();
        }
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
