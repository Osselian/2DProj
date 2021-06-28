using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _template;

    private Enemy[] _enemies;

    private void Start()
    {
        _enemies = new Enemy[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            Enemy gameObject = Instantiate(_template, transform.GetChild(i));
            _enemies[i] = gameObject;
        }
    } 
}
