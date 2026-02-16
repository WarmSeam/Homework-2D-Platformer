using System;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public event Action Rotated;

    private Quaternion _faceLeft;
    private Quaternion _faceRight;

    private bool _isDirectedRight = true;

    private void Awake()
    {
        _faceRight = Quaternion.Euler(0, 0, 0);
        _faceLeft = Quaternion.Euler(0, 180, 0);
    }

    public void Rotate(Vector3 direction)
    {
        if (direction.x == transform.position.x)
            return;

        bool isDirectedRight = direction.x > transform.position.x;

        if (isDirectedRight == _isDirectedRight)
            return;

        _isDirectedRight = isDirectedRight;

        transform.rotation = _isDirectedRight ? _faceRight : _faceLeft;

        Rotated?.Invoke();
    }
}
