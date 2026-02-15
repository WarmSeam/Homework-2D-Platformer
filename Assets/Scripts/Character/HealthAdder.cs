using System;using UnityEngine;

public class HealthAdder : MonoBehaviour
{
    public event Action<int> HealthAdded;

    public void HandleHealthAdding(int value)
    {
        HealthAdded?.Invoke(value);
    }
}
