using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private SpawnPoint[] _points;
    [SerializeField] private float _spawnDelay = 5;
    [SerializeField] private CoinCollector _collector;

    private IObjectPool<Coin> _pool;
    private WaitForSeconds _waitInterval;

    private int _maxSize;
    private int _countOneTime;
    private int _activeCount;
    private bool _isSpawning;

    private void Awake()
    {
        _maxSize = _points.Length;
        _countOneTime = _maxSize / 2;
        _activeCount = 0;

        _waitInterval = new WaitForSeconds(_spawnDelay);

        _pool = new ObjectPool<Coin>
            (CreateCoin,
            OnTakeFromPool,
            OnReturnedToPool,
            OnDestroyCoin,
            collectionCheck: true,
            defaultCapacity: _countOneTime,
            maxSize: _maxSize
            );
    }

    private void OnEnable()
    {
        _collector.CoinCollected += HandleCoinCollected;
    }

    private void OnDisable()
    {
        _collector.CoinCollected -= HandleCoinCollected;
    }

    private void Start()
    {
        if (_isSpawning == false)
        {
            _isSpawning = true;
            StartCoroutine(Spawn());
        }
    }

    private IEnumerator Spawn()
    {
        while (_isSpawning)
        {
            yield return _waitInterval;
            SpawnCoin();
        }
    }

    private void SpawnCoin()
    {
        SpawnPoint[] freePoints = _points.Where(point => point.IsOccupied == false).ToArray();

        if (freePoints.Length > 0 && _activeCount < _countOneTime)
        {
            SpawnPoint point = freePoints[UnityEngine.Random.Range(0, freePoints.Length)];

            Coin coin = _pool.Get();

            coin.transform.position = point.transform.position;

            coin.SetSpawnPoint(point);

            point.SetOccupied(true);
            _activeCount++;
        }
    }

    private void HandleCoinCollected(Coin coin)
    {
        coin.CurrentSpawnPoint.SetOccupied(false);

        _activeCount--;
        _pool.Release(coin);
    }

    private Coin CreateCoin()
    {
        Coin coin = Instantiate(_coinPrefab, transform);
        return coin;
    }

    private void OnTakeFromPool(Coin coin)
    {
        coin.gameObject.SetActive(true);
    }

    private void OnReturnedToPool(Coin coin)
    {
        coin.gameObject.SetActive(false);
    }

    private void OnDestroyCoin(Coin coin)
    {
        Destroy(coin);
    }
}
