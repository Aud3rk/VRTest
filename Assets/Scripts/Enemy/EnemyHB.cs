using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHB : MonoBehaviour
{
    [SerializeField] private Slider slider;
    
    private Transform _camera;
    private void Awake()
    {
        _camera = Camera.main.transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(_camera);
    }

    public void UpdateHealthBar(float health)
    {
        slider.value = health;
    }
}
