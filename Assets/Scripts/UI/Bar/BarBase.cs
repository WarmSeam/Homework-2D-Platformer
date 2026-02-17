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
        Slider.minValue = Health.Min;
        Slider.maxValue = Health.Max;

        Slider.value = Health.Current;
    }

    private void OnHealthChanged(int value)
    {
        UpdateView(value);
    }

    protected abstract void UpdateView(int value);
}