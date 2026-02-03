using System;
using UnityEngine;

[RequireComponent(typeof(HitDetector), typeof(Animator))]

public class HealthHandler : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private ItemCollector _collector;

    public event Action<int> HealthDecreased;
    public event Action<int> HealthIncreased;
    public event Action<bool> HealthOver;

    private HitDetector _hitDetector;

    private int _currentHealth;
    private bool _isDied;

    private void Awake()
    {
        _isDied = false;
        _currentHealth = _maxHealth;

        _hitDetector = GetComponent<HitDetector>();
    }

    private void OnEnable()
    {
        _hitDetector.HitTaken += TakeDamage;

        if(_collector != null )
        _collector.HealPickedUp += IncreaseHealth;
    }

    private void OnDisable()
    {
        _hitDetector.HitTaken -= TakeDamage;

        if (_collector != null)
            _collector.HealPickedUp -= IncreaseHealth;
    }

    private void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth < 0)
            _currentHealth = 0;

            HealthDecreased?.Invoke(_currentHealth);

        if (_currentHealth == 0)
        {
            _isDied = true;
            HealthOver?.Invoke(_isDied);
        }
    }

    private void IncreaseHealth(Heal heal)
    {
        _currentHealth += heal.Value;

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;

        HealthIncreased?.Invoke(_currentHealth);
    }
}
