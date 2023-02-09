using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using HurricaneVR.Framework.Components;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using Vector3 = UnityEngine.Vector3;

public class FireballController : HVRDamageHandlerBase
{
    private PlayerData _playerData;
    private Vector3 _target;
    private float _damage=30;

    [Inject] private TimerController _timerController;
    
    [SerializeField] private float _attackDistance = 0.2f;
    public void Initialize(PlayerData playerData)
    {
        _playerData = playerData;
        _target = playerData.gameObject.transform.position;
        _timerController.pauseMenu += Death;
    }
    void Update()
    {
        Move();
        Attack();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target,0.01f);
    }
    private void Attack()
    {
        if (Vector3.Distance(_playerData.gameObject.transform.position, transform.position) < _attackDistance)
        {
            _playerData.TakeDamage(_damage);
            Death();
        }
        else if(Vector3.Distance(_target,transform.position)<_attackDistance)
            Death();
    }
    public override void TakeDamage(float damage)
    {
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
