using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _max = 100;

    public event Action<int> Decreased;
    public event Action<int> Increased;
    public event Action<bool> Over;

    private int _min = 0;
    private int _current;
    private bool _isOver;

    public int Current => _current;
    public int Max => _max;
    public int Min => _min;

    private void Awake()
    {
        _isOver = false;
        _current = _max;
    }

    private void Start()
    {
        Increased?.Invoke(_current);
    }

    public void Decrease(int value)
    {
        if (_isOver)
            return;

        if (value < 0)
            value = 0;

        _current = Mathf.Clamp(_current - value, _min, _max);
        Decreased?.Invoke(_current);

        if (_current == _min)
        {
            _isOver = true;
            Over?.Invoke(_isOver);
        }
    }

    public void Increase(int value)
    {
        if (_isOver)
            return;

        if (value < _min)
            value = _min;

        _current = Mathf.Clamp(_current + value, _min, _max);
        Increased?.Invoke(_current);
    }
}
