using System.Collections;
using System.Collections.Generic;
using Installers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBomber : Enemy
{
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private EnemyHB enemyHB;
    
    private void Start()
    {
        maxHealth = 75f;
        currentHealth = maxHealth;
        timer = 3f;
        _agent = GetComponent<NavMeshAgent>();
        attackDistance = 7f;
        _enemyHB = enemyHB;
        timeCD = 2f;
    }

    private void Update()
    {
        Follow();
        if(Input.GetKeyDown(KeyCode.A))
            Death();
    }

    protected override void Follow()
    {
        _agent.destination = new Vector3(_playerData.gameObject.transform.position.x +2,
            _playerData.gameObject.transform.position.y, _playerData.gameObject.transform.position.z);
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
            var bomb =Instantiate(bombPrefab, transform.position, Quaternion.identity);
            Debug.Log("some");
            bomb.GetComponent<Bomb>().Initialize(_playerData,_timerController);
        }
    }

    protected override void Death()
    {
        _timerController.DeathEnemy(this.gameObject);
        Destroy(this.gameObject);
    }
}
