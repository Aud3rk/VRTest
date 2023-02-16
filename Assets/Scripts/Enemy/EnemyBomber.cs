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
    private float speed = 3f;
    
    
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
        Move();
        if(Input.GetKeyDown(KeyCode.A))
            Death();
    }

    protected override void Move()
    {
        transform.Translate(0,0,speed* Time.deltaTime);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            float currentDistance = hit.distance;
            if (currentDistance<2)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
        Attack();
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
