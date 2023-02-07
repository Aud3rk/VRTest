using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public float maxHealth = 100;
    public int waveNumber=1;
    public int goldCount=200;
    public int enemyDeadCount=0;
    
    private float _health = 100;
    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            SceneManager.LoadSceneAsync("Menu");
        }
    }

    public void ResetHealth()
    {
        _health = maxHealth;
    }
}
