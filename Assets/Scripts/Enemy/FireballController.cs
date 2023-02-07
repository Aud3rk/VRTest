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
    
    [SerializeField] private float _attackDistance = 0.2f;
    public void Initialize(PlayerData playerData)
    {
        _playerData = playerData;
        _target = playerData.gameObject.transform.position;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target,0.01f);
        Attack();
    }
    private void Attack()
    {
        if (Vector3.Distance(_playerData.gameObject.transform.position, transform.position) < _attackDistance)
        {
            _playerData.TakeDamage(_damage);
            Destroy(this.gameObject);
        }
        else if(Vector3.Distance(_target,transform.position)<_attackDistance)
            Destroy(this.gameObject);
    }
    public override void TakeDamage(float damage)
    {
        Destroy(this.gameObject);
    }
}
