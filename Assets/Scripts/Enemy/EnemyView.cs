using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Canvas _canvas;

    private void OnEnable()
    {
        _health.Over += OnDied;
    }

    private void OnDisable()
    {
        _health.Over -= OnDied;
    }

    private void OnDied(bool isDied)
    {
        if (isDied)
            _canvas.enabled = false;
    }
}