using System;
using System.Collections;
using System.Collections.Generic;
using HurricaneVR.Framework.Components;
using UnityEngine;
using UnityEngine.Lumin;

public class Bomb : HVRDamageHandlerBase
{
    private float _health=25;
    private float _attackDistance = 0.5f;
    private float _damage = 30;
    private PlayerData _player;

    public void Initialize(PlayerData player)
    {
        _player = player;
    }
    public override void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
            Destroy(this.gameObject);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < _attackDistance)
        {
            _player.TakeDamage(_damage);
            Destroy(this.gameObject);
        }
    }
}
