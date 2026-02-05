using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _max = 100;

    public event Action<int> Decreased;
    public event Action<int> Increased;
    public event Action<bool> Over;

    private int _current;
    private bool _isOver;

    private void Awake()
    {
        _isOver = false;
        _current = _max;
    }

    public void Decrease(int value)
    {
        if (_isOver)
            return;

        if (value < 0)
            value = 0;

        _current = Mathf.Clamp(_current - value, 0, _max);
        Decreased?.Invoke(_current);

        if (_current == 0)
        {
            _isOver = true;
            Over?.Invoke(_isOver);
        }
    }

    public void Increase(int value)
    {
        if (_isOver)
            return;

        if (value < 0)
            value = 0;

        _current = Mathf.Clamp(_current + value, 0, _max);
        Increased?.Invoke(_current);
    }
}
