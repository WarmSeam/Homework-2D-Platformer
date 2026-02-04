using System;
using System.Collections;
using UnityEngine;

public class PlayerFinder : MonoBehaviour
{
    [SerializeField] private Vector2 _boxSize = new(5f, 2f);
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _checkInterval = 0.3f;

    public event Action<Vector3> PlayerFound;
    public event Action PlayerLost;

    private WaitForSeconds _wait;
    private bool _isSearchActive;

    private void Awake()
    {
        _wait = new WaitForSeconds(_checkInterval);
    }

    private void Start()
    {
        _isSearchActive = true;
        StartCoroutine(CheckPlayer());
    }

    private void OnDisable()
    {
        _isSearchActive = false;
    }

    private IEnumerator CheckPlayer()
    {
        while (_isSearchActive)
        {
            yield return _wait;

            Collider2D hit = Physics2D.OverlapBox(transform.position, _boxSize, 0f, _layerMask);

            if (hit != null && hit.TryGetComponent(out Player player))
                PlayerFound?.Invoke(player.transform.position);
            else
                PlayerLost?.Invoke();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, _boxSize);
    }
}
