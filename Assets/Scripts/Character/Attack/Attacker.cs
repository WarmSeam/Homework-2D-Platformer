using System;
using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _animationStartDuration = 0.3f;
    [SerializeField] private float _attackDuration = 1f;
    [SerializeField] private int _damageAmount = 25;

    [SerializeField] private PunchZone _punchZone;
    [SerializeField] private LayerMask _layerMask;

    public event Action Attacking;

    private WaitForSeconds _waitAnimationStart;
    private WaitForSeconds _waitEndAttack;
    private IEnumerator _attackCoroutine;

    private void Awake()
    {
        _attackCoroutine = null;

        _waitEndAttack = new WaitForSeconds(_attackDuration);
        _waitAnimationStart = new WaitForSeconds(_animationStartDuration);
    }

    public void BeginAttack(bool isAttackLaunched)
    {
        if (isAttackLaunched)
            BeginAttack();
    }

    public void BeginAttack()
    {
        if (_attackCoroutine == null)
        {
            _attackCoroutine = Attack();
            StartCoroutine(_attackCoroutine);
        }
    }

    private IEnumerator Attack()
    {
        Attacking?.Invoke();

        yield return _waitAnimationStart;

        DealDamage();

        yield return _waitEndAttack;

        _attackCoroutine = null;
    }

    private void DealDamage()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _punchZone.Radius, _layerMask);

        if (hit != null && hit.TryGetComponent(out DamageTaker opponent))
            opponent.HandleTakingDamage(_damageAmount);
    }
}
