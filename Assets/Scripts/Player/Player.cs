using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(Rotator), typeof(AttackActivator))]

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private PlayerMovement _movement;
    private Rotator _rotator;
    private AttackActivator _attacker;
    private HealthHandler _healthHandler;

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _rotator = GetComponent<Rotator>();
        _attacker = GetComponent<AttackActivator>();
        _healthHandler = GetComponent<HealthHandler>();
    }

    private void OnEnable()
    {
        _inputReader.InputChanged += SetRotation;
        _inputReader.InputChanged += _movement.Move;
        _inputReader.RunPressed += _movement.Run;
        _inputReader.JumpRequested += _movement.Jump;
        _inputReader.AttackPressed += _attacker.BeginAttack;

        _healthHandler.HealthOver += Die;
    }

    private void OnDisable()
    {
        _inputReader.InputChanged -= SetRotation;
        _inputReader.InputChanged -= _movement.Move;
        _inputReader.RunPressed -= _movement.Run;
        _inputReader.JumpRequested -= _movement.Jump;

        _healthHandler.HealthOver -= Die;
    }

    private void SetRotation(float direction)
    {
        Vector3 targetDirection = new Vector3(direction, 0, 0) + transform.position;
        _rotator.Rotate(targetDirection);
    }

    private void Die(bool isDied)
    {
        if (isDied)
        {
            _inputReader.enabled = false;
            _movement.enabled = false;
            _rotator.enabled = false;
            _attacker.enabled = false;

            if (TryGetComponent(out Rigidbody2D rigidbody))
                rigidbody.bodyType = RigidbodyType2D.Static;

            if (TryGetComponent(out Collider2D collider))
                collider.enabled = false;
        }
    }
}
