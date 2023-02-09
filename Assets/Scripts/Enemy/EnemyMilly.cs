using System.Collections;
using System.Collections.Generic;
using Installers;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMilly : Enemy
{
    
    [SerializeField] private EnemyHB enemyHB;
    private void Start()
    {
        _damage = 100f;
        _maxHealth = 80f;
        _timer = 3f;
        _timeCD = 2f;
        _agent = GetComponent<NavMeshAgent>();
        _health = _maxHealth;
        _enemyHB = enemyHB;
    }

    private void Update()
    {
       Follow();
       if(Input.GetKeyDown(KeyCode.A))
           Death();
    }

    protected override void Follow()
    {
        _agent.destination = _player.gameObject.transform.position;
        if (Vector3.Distance(_player.gameObject.transform.position, _agent.gameObject.transform.position) < _attackDistance)
        {
            Attack();
        }
        
    }

    protected override void Attack()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _timer = _timeCD;
            _player.TakeDamage(_damage);
        }
    }
}
