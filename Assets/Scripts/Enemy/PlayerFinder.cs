using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class PlayerFinder : MonoBehaviour
{
    private BoxCollider2D _collider;

    public event Action<Vector3> PlayerFound;
    public event Action PlayerLost;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _collider.isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            Vector3 playerPosition = player.transform.position;

            PlayerFound?.Invoke(playerPosition);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        PlayerLost?.Invoke();
    }
}
