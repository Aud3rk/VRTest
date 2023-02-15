using HurricaneVR.Framework.Components;
using UnityEngine;
using UnityEngine.AI;

namespace Installers
{
    public abstract class  Enemy : HVRDamageHandlerBase
    {
        protected TimerController _timerController;
        protected NavMeshAgent _agent;
        protected PlayerData _playerData;
        protected EnemyHB _enemyHB;

        protected float currentHealth;
        protected float maxHealth;
        protected float attackDistance=2f;
        protected float timer;
        protected float timeCD;
        protected float damage;

        public void Initialize(PlayerData playerData, TimerController timerController)
        {
            _timerController = timerController;
            _playerData = playerData;
        }
        public override void TakeDamage(float damage)
        {
            currentHealth -= damage;
            _enemyHB.UpdateHealthBar(currentHealth/maxHealth);
            if (currentHealth <= 0)
            {
                Death();
            }
        }
    
        protected virtual void Death()
        {
            _timerController.DeathEnemy(this.gameObject);
            Destroy(this.gameObject);
        }

        protected abstract void Follow();

        protected abstract void Attack();

    }
}