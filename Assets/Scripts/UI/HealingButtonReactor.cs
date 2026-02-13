using UnityEngine;

[RequireComponent (typeof(HealthChangerButton))]
public class HealingButtonReactor : MonoBehaviour
{
    [SerializeField] private HealthAdder _healthAdder;

    private HealthChangerButton _button;

    private void Awake()
    {
        _button = GetComponent<HealthChangerButton>();
    }

    private void OnEnable()
    {
        _button.Clicked += _healthAdder.HandleHealthAdding;
    }

    private void OnDisable()
    {
        _button.Clicked -= _healthAdder.HandleHealthAdding;
    }
}
