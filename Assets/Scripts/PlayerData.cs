using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    
    private float maxHealth = 100;
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
