using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Color _color = Color.red;

    public bool IsOccupied {  get; private set; }

    public void SetOccupied(bool value)
    {
        IsOccupied = value;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _color;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}
