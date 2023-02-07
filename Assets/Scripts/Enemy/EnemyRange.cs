using System;
using UnityEngine;
using UnityEngine.AI;

namespace Installers
{
    public class EnemyRange : Enemy
    {
        [SerializeField] private EnemyHB enemyHB;
        [SerializeField] private GameObject fireballPrefab;

        private void Start()
        {
            _maxHealth = 50;
            _agent = GetComponent<NavMeshAgent>();
            _attackDistance = 7f;
            _health = _maxHealth;
            _enemyHB = enemyHB;
            _timeCD = 3f;
        }
        private void Update()
        {
            Follow();
        }
        protected override void Follow()
        {
            _agent.destination = new Vector3(_player.gameObject.transform.position.x - 6,
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
                var ball =Instantiate(fireballPrefab,
                    new Vector3(transform.position.x, transform.position.y+2, transform.position.z),
                    Quaternion.identity);
                ball.GetComponent<FireballController>().Initialize(_player);
                _timer = _timeCD;
            }
        }
    }
}