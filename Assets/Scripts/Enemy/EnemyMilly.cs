using System.Collections;
using System.Collections.Generic;
using Installers;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMilly : Enemy
{
    
    [SerializeField] private EnemyHB enemyHB;
    private void Awake()
    {
        maxHealth = 80f;
        currentHealth = maxHealth;
        damage = 20f;
        timer = 3f;
        timeCD = 2f;
        _agent = GetComponent<NavMeshAgent>();
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
        _agent.destination = _playerData.gameObject.transform.position;
        if(PlayerInADistance())
            Attack();
    }

    private bool PlayerInADistance()
    {
        return (Vector3.Distance(_playerData.gameObject.transform.position, _agent.gameObject.transform.position) < attackDistance);
    }

    protected override void Attack()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeCD;
            _playerData.TakeDamage(damage);
        }
    }
}
