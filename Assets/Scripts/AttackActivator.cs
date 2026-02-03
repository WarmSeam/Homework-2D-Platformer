using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimationChanger))]

public class AttackActivator : MonoBehaviour
{
    [SerializeField] private DamageCarrier _damageCarrier;
    [SerializeField] private float _duration = 1f;

    private PlayerAnimationChanger _animationChanger;
    private WaitForSeconds _wait;
    private IEnumerator _attackCoroutine;

    private void Awake()
    {
        _animationChanger = GetComponent<PlayerAnimationChanger>();

        _attackCoroutine = null;
        _wait = new WaitForSeconds(_duration);

        _damageCarrier.gameObject.SetActive(false);
    }

    public void BeginAttack(bool isAttackLaunched)
    {
        if (_attackCoroutine == null && isAttackLaunched)
        {
            _attackCoroutine = Attack();
            StartCoroutine(_attackCoroutine);
        }
    }

    private IEnumerator Attack()
    {
        _animationChanger.ActivateAttackTrigger();

        _damageCarrier.gameObject.SetActive(true);

        yield return _wait;

        _damageCarrier.gameObject.SetActive(false);

        _attackCoroutine = null;
    }
}
