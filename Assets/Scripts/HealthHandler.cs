using System;
using UnityEngine;

[RequireComponent(typeof(HitDetector))]

public class HealthHandler : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;

    private HitDetector _hitDetector;

    private int _currentHealth;

    public event Action<int> HealthChanged;
    public event Action HealthOver;

    private void Awake()
    {
        _currentHealth = _maxHealth;

        _hitDetector = GetComponent<HitDetector>();
    }

    private void OnEnable()
    {
        _hitDetector.DamageTaken += TakeDamage;
    }

    private void OnDisable()
    {
        _hitDetector.DamageTaken += TakeDamage;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth);

        if(_currentHealth <= 0)
        {
            _currentHealth = 0;
            HealthOver?.Invoke();
        }
    }

}
