using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerRotator))]

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private PlayerMovement _movement;
    private PlayerRotator _rotator;

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _rotator = GetComponent<PlayerRotator>();
    }

    private void OnEnable()
    {
        _inputReader.InputChanged += _movement.Move;
        _inputReader.InputChanged += _rotator.Rotate;
        _inputReader.RunPressed += _movement.Run;
        _inputReader.JumpRequested += _movement.Jump;
    }

    private void OnDisable()
    {
        _inputReader.InputChanged -= _movement.Move;
        _inputReader.InputChanged -= _rotator.Rotate;
        _inputReader.RunPressed -= _movement.Run;
        _inputReader.JumpRequested -= _movement.Jump;
    }
}
