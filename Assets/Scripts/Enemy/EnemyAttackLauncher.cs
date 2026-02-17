using UnityEngine;

[RequireComponent (typeof(Attacker))]
public class EnemyAttackLauncher : MonoBehaviour
{
    [SerializeField] private DestinationSelector _destinationSelector;

    private Attacker _attack;

    private void Awake()
    {
        _attack = GetComponent<Attacker>();
    }

    private void OnEnable()
    {
        if (_destinationSelector != null)
            _destinationSelector.PlayerClose += OnPlayerClose;
    }

    private void OnDisable()
    {
        if (_destinationSelector != null)
            _destinationSelector.PlayerClose -= OnPlayerClose;
    }

    private void OnPlayerClose(bool isPlayerClose)
    {
        if (isPlayerClose)
        _attack.BeginAttack();
    }
}
