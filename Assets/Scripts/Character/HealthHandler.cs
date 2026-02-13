using UnityEngine;

[RequireComponent(typeof(Health), typeof(DamageTaker), typeof(HealthAdder))]
public class HealthHandler : MonoBehaviour
{
    [SerializeField] private ItemCollector _itemCollector;

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

        if (_itemCollector != null)
            _itemCollector.HealCollected += IncreaseHealth;
    }

    private void OnDisable()
    {
        _damageTaker.DamageTaken -= DecreaseHealth;
        _healthAdder.HealthAdded -= IncreaseHealth;

        if (_itemCollector != null)
            _itemCollector.HealCollected -= IncreaseHealth;
    }

    private void DecreaseHealth(int damage)
    {
        _health.Decrease(damage);
    }

    private void IncreaseHealth(int value)
    {
        _health.Increase(value);
    }
}

