using UnityEngine;

[RequireComponent(typeof(Health), typeof(DamageTaker), typeof(HealthAdder))]
public class HealthHandler : MonoBehaviour
{
    private Health _health;
    private DamageTaker _damageTaker;
    private HealthAdder _healthAdder;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _damageTaker = GetComponent<DamageTaker>();
        _healthAdder = GetComponent<HealthAdder>();
    }

    private void OnEnable()
    {
        _damageTaker.DamageTaken += DecreaseHealth;
        _healthAdder.HealthAdded += IncreaseHealth;
    }

    private void OnDisable()
    {
        _damageTaker.DamageTaken -= DecreaseHealth;
        _healthAdder.HealthAdded -= IncreaseHealth;
    }

    private void DecreaseHealth(int value)
    {
        _health.Decrease(value);
    }

    private void IncreaseHealth(int value)
    {
        _health.Increase(value);
    }
}

