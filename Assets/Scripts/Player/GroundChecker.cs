using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _distance = 0.2f;

    public event Action<bool> GroundStateChanged;

    private bool _lastGroundState;

    private void Start()
    {
        _lastGroundState = true;
    }

    private void Update()
    {
        UpdateGroundState();
    }

    private void UpdateGroundState()
    {
        bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, _distance, _groundLayer);

        if (isGrounded != _lastGroundState)
        {
            GroundStateChanged?.Invoke(isGrounded);
            _lastGroundState = isGrounded;
        }
    }
}
