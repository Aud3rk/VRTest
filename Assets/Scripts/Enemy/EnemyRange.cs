using System;
using UnityEngine;
using UnityEngine.AI;

namespace Installers
{
    public class EnemyRange : Enemy
    {
        [SerializeField] private EnemyHB enemyHB;
        [SerializeField] private GameObject fireballPrefab;
        private float _followDistantl = 5f;

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
            if(Input.GetKeyDown(KeyCode.A))
                Death();
        }
        protected override void Follow()
        {
            var distant = Vector3.Distance(_player.gameObject.transform.position, _agent.gameObject.transform.position);

            if (distant > _followDistantl)
            {
                _agent.destination = _player.gameObject.transform.position;
            }
            else 
            {
                _agent.destination = transform.position;
                if (distant < _attackDistance)
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