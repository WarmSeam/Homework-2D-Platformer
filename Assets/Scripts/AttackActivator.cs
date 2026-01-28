using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AttackActivator : MonoBehaviour
{
    public readonly int AttackTrigger = Animator.StringToHash(nameof(AttackTrigger));

    [SerializeField] private DamageCarrier _damageCarrier;
    [SerializeField] private float _duration = 1f;

    private Animator _animator;
    private WaitForSeconds _wait;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        _wait = new WaitForSeconds(_duration);

        _damageCarrier.gameObject.SetActive(false);
    }

    public void BeginAttack(bool isHitted)
    {
        if (isHitted)
            StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        _animator.SetTrigger(AttackTrigger);
        _damageCarrier.gameObject.SetActive(true);

        yield return _wait;

        _damageCarrier.gameObject.SetActive(false);
    }

}
