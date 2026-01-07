using System;
using UnityEngine;

public class EndPathChecker : MonoBehaviour
{
    [SerializeField] private float _distance = 0.5f;
    [SerializeField] private LayerMask _groundLayer;

    public event Action EndReached;

    private void Update()
    {
        UpdatePathState();
    }

    private void UpdatePathState()
    {
        bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, _distance, _groundLayer);
        bool isObstacleAhead = Physics2D.Raycast(transform.position, Vector2.zero, 0, _groundLayer);

        if (isObstacleAhead || isGrounded == false)
        {
            EndReached?.Invoke();
        }
    }
}