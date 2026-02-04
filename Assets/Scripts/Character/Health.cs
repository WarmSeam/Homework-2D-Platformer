using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;

    public event Action<int> HealthDecreased;
    public event Action<int> HealthIncreased;
    public event Action<bool> HealthOver;

    private int _currentHealth;
    private bool _isDied;

    private void Awake()
    {
        _isDied = false;
        _currentHealth = _maxHealth;
    }

    public void Decrease(int value)
    {
        if (_isDied)
            return;

        if (value < 0)
            value = 0;

        _currentHealth = Mathf.Clamp(_currentHealth - value, 0, _maxHealth);
        HealthDecreased?.Invoke(_currentHealth);

        if (_currentHealth == 0)
        {
            _isDied = true;
            HealthOver?.Invoke(_isDied);
        }
    }

    public void Increase(int value)
    {
        if (_isDied)
            return;

        if (value < 0)
            value = 0;

        _currentHealth = Mathf.Clamp(_currentHealth + value, 0, _maxHealth);
        HealthIncreased?.Invoke(_currentHealth);
    }
}
