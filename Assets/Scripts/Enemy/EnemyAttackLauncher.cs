using UnityEngine;

public class EnemyAttackLauncher : MonoBehaviour
{
    [SerializeField] private Attacker _attack;
    [SerializeField] private DestinationSelector _destinationSelector;

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
