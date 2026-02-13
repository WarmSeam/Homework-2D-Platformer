using UnityEngine;

[RequireComponent(typeof(HealthChangerButton))]
public class DamagingButtonReactor : MonoBehaviour
{
    [SerializeField] private DamageTaker _damageTaker;

    private HealthChangerButton _button;

    private void Awake()
    {
        _button = GetComponent<HealthChangerButton>();
    }

    private void OnEnable()
    {
        _button.Clicked += _damageTaker.HandleTakingDamage;
    }

    private void OnDisable()
    {
        _button.Clicked -= _damageTaker.HandleTakingDamage;
    }
}

