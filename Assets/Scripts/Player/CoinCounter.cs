using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private CoinCollector _coinCollector;

    private int _count;

    private void Awake()
    {
        _count = 0;
    }

    private void OnEnable()
    {
        if(_coinCollector != null) 
        _coinCollector.CoinCollected += IncreaseCount;
    }

    private void OnDisable()
    {
        if (_coinCollector != null)
            _coinCollector.CoinCollected -= IncreaseCount;
    }

    private void IncreaseCount()
    {
        _count += 1;
        Debug.Log("Coins: " + _count);
    }

}
