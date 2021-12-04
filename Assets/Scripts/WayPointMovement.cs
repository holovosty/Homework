using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;
    public Vector3 Direction { get; private set; }

    private Transform[] _points;
    private int _currentPoint;

    void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    void GetDirection(Transform target)
    {
        Direction = (target.position - transform.position).normalized;
    }

    void PointMovement()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 1;
            }
        }

        GetDirection(target);
    }


    void Update()
    {
        PointMovement();
    }
}
