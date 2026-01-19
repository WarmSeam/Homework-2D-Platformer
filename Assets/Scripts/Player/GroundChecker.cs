using System;
using System.Collections;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _distance = 0.2f;
    [SerializeField] private float _checkDelayInSeconds = 0.1f;

    public event Action<bool> GroundStateChanged;

    private bool _lastGroundState;
    private WaitForSeconds _wait;

    private void Awake()
    {
        _wait = new WaitForSeconds(_checkDelayInSeconds);
    }

    private void Start()
    {
        _lastGroundState = true;
        StartCoroutine(UpdateGroundState());
    }

    private IEnumerator UpdateGroundState()
    {
        while (gameObject != null)
        {
            yield return _wait;

            bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, _distance, _groundLayer);

            if (isGrounded != _lastGroundState)
            {
                GroundStateChanged?.Invoke(isGrounded);
                _lastGroundState = isGrounded;
            }
        }
    }
}