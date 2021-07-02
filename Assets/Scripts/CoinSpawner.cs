using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _template;
    [SerializeField] private float _spawnTime;

    private Transform[] _spawnPoints;
    private int _index;
    private float _timePassed;

    private void Start()
    {
        _spawnPoints = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _spawnPoints[i] = transform.GetChild(i);
        }
    }

    private void Update()
    {
        _timePassed += Time.deltaTime;
        if (_timePassed > _spawnTime)
        {
            _index = Random.Range(0, _spawnPoints.Length);
            Coin coin = Instantiate(_template, _spawnPoints[_index]);
            _timePassed = 0;
        }
    }
}
