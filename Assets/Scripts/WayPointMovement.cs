using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _targetPoint;

    public void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    public Vector3 GetDirection()
    {
        Vector3 direction = (_points[_targetPoint].position - transform.position).normalized;
        return direction;
    }

    private void MoveByPoints()
    {
        Transform target = _points[_targetPoint];

        transform.position = Vector3.MoveTowards(transform.position, _points[_targetPoint].position, _speed * Time.deltaTime);

        if (transform.position == _points[_targetPoint].position)
        {
            _targetPoint++;

            if (_targetPoint >= _points.Length)
            {
                _targetPoint = 1;
            }
        }

        GetDirection();
    }

    public void Update()
    {
        MoveByPoints();
    }
}
