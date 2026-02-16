using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class InstantBar : BarBase
{
    protected override void UpdateView(int value)
    {
        _slider.value = value;
    }
}
