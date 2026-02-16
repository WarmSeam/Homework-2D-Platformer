using System;
using UnityEngine;

public class HealthAdder : MonoBehaviour
{
    [SerializeField] ItemCollector _itemCollector;

    public event Action<int> HealthAdded;

    private void OnEnable()
    {
        if (_itemCollector != null)
            _itemCollector.HealCollected += HandleHealthAdding;
    }

    private void OnDisable()
    {
       if (_itemCollector != null)
            _itemCollector.HealCollected -= HandleHealthAdding;
    }

    public void HandleHealthAdding(int value)
    {
        HealthAdded?.Invoke(value);
    }
}
