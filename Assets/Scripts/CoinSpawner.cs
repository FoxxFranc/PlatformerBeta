using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform _coinSpawner;
    [SerializeField] private Player _player;
    [SerializeField] private Coin _template;
    [SerializeField] private float _timeBetweenSpawns;
    
    private Transform _transform;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_coinSpawner.childCount];

        for (int i = 0; i < _coinSpawner.childCount; i++)
        {
            _points[i] = _coinSpawner.GetChild(i);
        }

        StartCoroutine(SpawnCoins());
    }
  
    private IEnumerator SpawnCoins()
    {
        while (_player.HitPoints > 0)
        {
            yield return new WaitForSecondsRealtime(_timeBetweenSpawns);
            Instantiate(_template, GetRandomPoint(_points));
            
        }
    }

    private Transform GetRandomPoint(Transform[] points)
    {
        int indexOfRandomPoint = Random.Range(0, points.Length);
        Transform randomPointPosition = points[indexOfRandomPoint];
        return randomPointPosition;
    }
}
