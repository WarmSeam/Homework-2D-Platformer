using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealSpawner : MonoBehaviour
{
    [SerializeField] private Heal _healPrefab;
    [SerializeField] private HealSpawnPoint[] _points;
    [SerializeField] private ItemCollector _collector;

    private int _healsCount;
    private int _healToPointsRatio = 2;

    private void Awake()
    {
        _healsCount = _points.Length / _healToPointsRatio;
    }

    private void OnEnable()
    {
        _collector.HealPickedUp += DestroyHeal;
    }

    private void OnDisable()
    {
        _collector.HealPickedUp -= DestroyHeal;
    }

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        HealSpawnPoint[] _randomPoints = _points.OrderBy(_ => Random.value).Take(_healsCount).ToArray();

        foreach (var point in _randomPoints)
            Instantiate(_healPrefab, point.transform.position, Quaternion.identity, transform);
    }

    private void DestroyHeal(Heal heal)
    {
      Destroy(heal.gameObject);
    }
}
