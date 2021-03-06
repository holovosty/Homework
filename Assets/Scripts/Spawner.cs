using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _templatePrefab;
    [SerializeField] private Transform _spawnPoints;

    private WaitForSeconds _spawnInterval = new WaitForSeconds(2);
    private Transform[] _instantiantePoints;
    private int _currentPoint;



    public void Start()
    {
        _instantiantePoints = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _instantiantePoints[i] = _spawnPoints.GetChild(i);
        }

        StartCoroutine(InstantiateEnemy());
    }

    private IEnumerator InstantiateEnemy()
    {
        while (true)
        {
            Transform instantiatePosition = _instantiantePoints[_currentPoint];
            GameObject newEnemy = Instantiate(_templatePrefab, instantiatePosition.position, Quaternion.identity);

            if (_currentPoint < _instantiantePoints.Length - 1)
            {
                _currentPoint++;
            }
            else
            {
                _currentPoint = 0;
            }

            yield return _spawnInterval;
        }
    }
}
