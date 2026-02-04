using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.HealthDecreased += DisplayHealthValue;
        _health.HealthIncreased += DisplayHealthValue;
    }

    private void OnDisable()
    {
        _health.HealthDecreased -= DisplayHealthValue;
        _health.HealthIncreased -= DisplayHealthValue;
    }
    private void DisplayHealthValue(int value)
    {
        Debug.Log(_health.gameObject.name + ": " + value);
    }
}
