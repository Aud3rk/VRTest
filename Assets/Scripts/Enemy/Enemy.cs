using HurricaneVR.Framework.Components;
using UnityEngine;
using UnityEngine.AI;

namespace Installers
{
    public abstract class  Enemy : HVRDamageHandlerBase
    {
        protected TimerController _timerController;
        protected NavMeshAgent _agent;
        protected PlayerData _player;
        protected EnemyHB _enemyHB;
        
        protected float _maxHealth;
        protected float _health;
        protected float _attackDistance=2f;
        protected float _timer;
        protected float _timeCD;
        protected float _damage;

        public void Initialize(PlayerData player, TimerController timerController)
        {
            _player = player;
            _timerController = timerController;
        }
        

        public override void TakeDamage(float damage)
        {
            _health -= damage;
            _enemyHB.UpdateHealthBar(_health/_maxHealth);
            if (_health <= 0)
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