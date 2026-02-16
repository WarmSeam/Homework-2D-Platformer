using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class BarBase : MonoBehaviour
{
    [SerializeField] protected Health _health;

    protected Slider _slider;

    protected virtual void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    protected virtual void Start()
    {
        SetSliderValues();
    }

    protected virtual void OnEnable()
    {
        _health.Decreased += OnHealthChanged;
        _health.Increased += OnHealthChanged;
    }

    protected virtual void OnDisable()
    {
        _health.Decreased -= OnHealthChanged;
        _health.Increased -= OnHealthChanged;
    }

    protected void SetSliderValues()
    {
        _slider.minValue = _health.Min;
        _slider.maxValue = _health.Max;

        _slider.value = _health.Current;
    }

    private void OnHealthChanged(int value)
    {
        UpdateView(value);
    }

    protected abstract void UpdateView(int value);
}