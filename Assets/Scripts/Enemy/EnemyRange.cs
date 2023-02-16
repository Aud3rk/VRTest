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

        private void Awake()
        {
            
            maxHealth = 50f;
            currentHealth = maxHealth;
            _agent = GetComponent<NavMeshAgent>();
            attackDistance = 7f;
            _enemyHB = enemyHB;
            timeCD = 3f;
        }
        private void Update()
        {
            Move();
            if(Input.GetKeyDown(KeyCode.A))
                Death();
        }
        protected override void Move()
        {
            var distant = Vector3.Distance(_playerData.gameObject.transform.position, _agent.gameObject.transform.position);

            if (distant > _followDistantl)
            {
                _agent.destination = _playerData.gameObject.transform.position;
            }
            else 
            {
                _agent.destination = transform.position;
                if (distant < attackDistance)
                    Attack();
            }
        }
        protected override void Attack()
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                var ball =Instantiate(fireballPrefab,
                    new Vector3(transform.position.x, transform.position.y+2, transform.position.z),
                    Quaternion.identity);
                ball.GetComponent<FireballController>().Initialize(_playerData, _timerController);
                timer = timeCD;
            }
        }
    }
}