using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] PatrolPoints;
    public float Speed = 1f;
    public float StartWaitTime;

    private int _currentPointIndex;
    private float _waitTime;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = PatrolPoints[0].position;
        transform.rotation = PatrolPoints[0].rotation;
        _waitTime = StartWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, PatrolPoints[_currentPointIndex].position, Speed * Time.deltaTime);

        if (transform.position == PatrolPoints[_currentPointIndex].position)
        {
            if (_waitTime <= 0)
            {
                if (_currentPointIndex + 1 < PatrolPoints.Length)
                {
                    _currentPointIndex++;
                }
                else
                {
                    _currentPointIndex = 0;
                }
                _waitTime = StartWaitTime;
            }
            else
            {
                _waitTime -= Time.deltaTime;
            }
        }
        else
        {
            transform.rotation = PatrolPoints[_currentPointIndex].rotation;
        }
    }
}