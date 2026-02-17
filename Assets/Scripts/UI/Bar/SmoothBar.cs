using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothBar : BarBase
{
    [SerializeField] private float _speed;

    private Coroutine _updateBarCortoutine;

    protected override void UpdateView(int value)
    {
        if (_updateBarCortoutine != null)
            StopCoroutine(_updateBarCortoutine);

        _updateBarCortoutine = StartCoroutine(UpdateBar(value));
    }

    private IEnumerator UpdateBar(int value)
    {
        while (Slider.value != value)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, value, _speed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

        _updateBarCortoutine = null;
    }
}
