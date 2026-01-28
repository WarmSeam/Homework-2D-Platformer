using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private HealthHandler _health;

    private void OnEnable()
    {
        _health.HealthChanged += DisplayValue;
    }

    private void OnDisable()
    {
        _health.HealthChanged += DisplayValue;
    }
    private void DisplayValue(int value)
    {
        Debug.Log(_health.gameObject.name + ": " + value);
    }
}
