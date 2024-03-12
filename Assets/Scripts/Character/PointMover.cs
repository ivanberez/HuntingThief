using UnityEngine;
using System;

public class PointMover : MonoBehaviour
{
    private const int StartIndexPoint = 0;

    [SerializeField] private float _speed;
    [SerializeField] private Transform _parentPoints;

    private Transform[] _points;
    private Vector3 _targetPosition;
    private int _indexPoint;

    public Action<Vector2> ChangeDirection;

    private void Start()
    {
        _points = new Transform[_parentPoints.childCount];

        for (int i = 0; i < _points.Length; i++)
            _points[i] = _parentPoints.GetChild(i);

        _targetPosition = _points[_indexPoint = StartIndexPoint].position;
    }

    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

        if (transform.position == _targetPosition)
            SetTargetPoint();
    }

    private void SetTargetPoint()
    {
        _indexPoint = (++_indexPoint) % _points.Length;

        _targetPosition = _points[_indexPoint].position;

        Vector2 corectDirection = VectorCorrection(transform.position - _targetPosition);
        ChangeDirection?.Invoke(corectDirection);        
    }                               

    private Vector2 VectorCorrection(Vector2 changedPosition)
    {
        var x = changedPosition.x < 0 ? -changedPosition.x : changedPosition.x;
        var y = changedPosition.y < 0 ? -changedPosition.y : changedPosition.y;

        if (x > y)
            return new Vector2(changedPosition.x, 0);
        else
            return new Vector2(0, changedPosition.y);
    }
}