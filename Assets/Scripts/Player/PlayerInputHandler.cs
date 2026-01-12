using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private PlayerMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        _inputReader.InputChanged += _movement.Move;
        _inputReader.RunPressed += _movement.Run;
        _inputReader.JumpRequested += _movement.Jump;
    }

    private void OnDisable()
    {
        _inputReader.InputChanged -= _movement.Move;
        _inputReader.RunPressed -= _movement.Run;
        _inputReader.JumpRequested -= _movement.Jump;
    }
}
