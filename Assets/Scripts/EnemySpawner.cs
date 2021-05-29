using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _spawnPointsList;    
    [SerializeField] private float _spawnTime;

    private Transform[] _spawnPoints;
    private int _index;
    private float _spawnTimer;

    private void Start()
    {
        _spawnPoints = new Transform[_spawnPointsList.childCount];

        for (int i = 0; i < _spawnPointsList.childCount; i++)
        {
            _spawnPoints[i] = _spawnPointsList.GetChild(i);
        }
        
    }
    private void Update()
    {
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer > _spawnTime )
        {
            _index = Random.Range(0, _spawnPoints.Length);
            GameObject gameObject = Instantiate(_template, _spawnPoints[_index]);
            _spawnTimer = 0;
        }        
      
    }
}
