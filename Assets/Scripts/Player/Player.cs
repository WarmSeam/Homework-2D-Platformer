using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(Rotator))]

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private PlayerMovement _movement;
    private Rotator _rotator;
    private AttackActivator _attacker;

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _rotator = GetComponent<Rotator>();
        _attacker = GetComponent<AttackActivator>();
    }

    private void OnEnable()
    {
        _inputReader.InputChanged += SetRotation;
        _inputReader.InputChanged += _movement.Move;
        _inputReader.RunPressed += _movement.Run;
        _inputReader.JumpRequested += _movement.Jump;
        _inputReader.HitPressed += _attacker.BeginAttack;
    }

    private void OnDisable()
    {
        _inputReader.InputChanged -= SetRotation;
        _inputReader.InputChanged -= _movement.Move;
        _inputReader.RunPressed -= _movement.Run;
        _inputReader.JumpRequested -= _movement.Jump;
    }

    private void SetRotation(float direction)
    {
        Vector3 targetDirection = new Vector3(direction, 0, 0) + transform.position;
        _rotator.Rotate(targetDirection);
    }
}
