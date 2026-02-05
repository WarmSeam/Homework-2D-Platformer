using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.Decreased += DisplayHealthValue;
        _health.Increased += DisplayHealthValue;
    }

    private void OnDisable()
    {
        _health.Decreased -= DisplayHealthValue;
        _health.Increased -= DisplayHealthValue;
    }
    private void DisplayHealthValue(int value)
    {
        Debug.Log(_health.gameObject.name + ": " + value);
    }
}
