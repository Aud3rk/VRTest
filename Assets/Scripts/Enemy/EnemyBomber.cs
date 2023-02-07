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
    private List<GameObject> _bombList;
    
    private void Start()
    {
        _maxHealth = 75;
        _timer = 3f;
        _agent = GetComponent<NavMeshAgent>();
        _attackDistance = 7f;
        _health = _maxHealth;
        _enemyHB = enemyHB;
        _timeCD = 2f;
        _bombList = new List<GameObject>();
    }

    private void Update()
    {
        Follow();
    }

    protected override void Follow()
    {
        _agent.destination = new Vector3(_player.gameObject.transform.position.x +2,
            _player.gameObject.transform.position.y, _player.gameObject.transform.position.z);
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
            var bomb =Instantiate(bombPrefab,
                new Vector3(transform.position.x, transform.position.y, transform.position.z),
                Quaternion.identity);
            bomb.GetComponent<Bomb>().Initialize(_player);
            _bombList.Add(bomb);
            
        }
    }

    protected override void Death()
    {
        foreach (var bomb in _bombList)
        {
            Destroy(bomb);
        }
        _timerController.DeathEnemy(this.gameObject);
        Destroy(this.gameObject);
    }
}
