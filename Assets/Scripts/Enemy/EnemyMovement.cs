using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _patrolArea;
    [SerializeField] private float _speed;

    private Vector3[] _patrolPoints;
    private int _currentPoint;

    private void Start()
    {
        _patrolPoints = new Vector3[_patrolArea.childCount];
        for (int i = 0; i < _patrolArea.childCount; i++)
        {
            _patrolPoints[i] = _patrolArea.GetChild(i).position;
        }
    }

    private void Update()
    {
        Vector3 target = _patrolPoints[_currentPoint];
        var direction = (target - base.transform.position).normalized;

        base.transform.position = Vector3.MoveTowards(base.transform.position, target, _speed * Time.deltaTime);

        if (base.transform.position == target)
        {
            _currentPoint++;
            if (_currentPoint >= _patrolPoints.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}
