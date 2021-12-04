using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject _tempFab;
    [SerializeField] private Transform _spawn;

    private Transform[] _instantiantePoints;
    private int _currentPoint;

    void Start()
    {
        _instantiantePoints = new Transform[_spawn.childCount];

        for (int i = 0; i < _spawn.childCount; i++)
        {
            _instantiantePoints[i] = _spawn.GetChild(i);
        }

        StartCoroutine(InstantiateEnemy());
    }

    void Repeat()
    {
        StartCoroutine(InstantiateEnemy());
    }

    IEnumerator InstantiateEnemy()
    {
        yield return new WaitForSeconds(2);

        Transform instantiatePosition = _instantiantePoints[_currentPoint];
        GameObject newEnemy = Instantiate(_tempFab, instantiatePosition.position, Quaternion.identity);

        if (_currentPoint < _instantiantePoints.Length-1)
        {
            _currentPoint++;
        }
        else
        {
            _currentPoint = 0;
        }

        Repeat();
    }
}