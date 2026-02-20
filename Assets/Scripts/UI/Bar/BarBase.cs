using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class BarBase : MonoBehaviour
{
    [SerializeField] protected Health Health;

    protected Slider Slider;

    protected virtual void Awake()
    {
        Slider = GetComponent<Slider>();
    }

    protected virtual void Start()
    {
        SetSliderValues();
    }

    protected virtual void OnEnable()
    {
        Health.Decreased += OnHealthChanged;
        Health.Increased += OnHealthChanged;
    }

    protected virtual void OnDisable()
    {
        Health.Decreased -= OnHealthChanged;
        Health.Increased -= OnHealthChanged;
    }

    protected void SetSliderValues()
    {
        Slider.minValue = 0f;
        Slider.maxValue = 1f;

        Slider.value = Health.Current;
    }

    private void OnHealthChanged(int value)
    {
        UpdateView(GetNormalizedValue());
    }

    private float GetNormalizedValue()
    {
        return Health.Current / (float)Health.Max;
    }

    protected abstract void UpdateView(float value);
}