using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    [SerializeField] private AttackActivator _attack;
    [SerializeField] private DestinationSelector _destinationSelector;

    private void OnEnable()
    {
        if (_destinationSelector != null)
            _destinationSelector.PlayerClose += HandleApproach;
    }

    private void OnDisable()
    {
        if (_destinationSelector != null)
            _destinationSelector.PlayerClose -= HandleApproach;
    }

    private void HandleApproach(bool isAttackLaunched)
    {
        _attack.BeginAttack(isAttackLaunched);
    }
}
