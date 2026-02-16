using UnityEngine;

public class IgnoreRotateUI : MonoBehaviour
{
    [SerializeField] private Rotator _rotator;

    private void OnEnable()
    {
        if (_rotator != null)
            _rotator.Rotated += IgnoreRotation;
    }

    private void OnDisable()
    {
        if (_rotator != null)
            _rotator.Rotated -= IgnoreRotation;
    }

    private void IgnoreRotation()
    {
        transform.rotation = Quaternion.identity;
    }
}
