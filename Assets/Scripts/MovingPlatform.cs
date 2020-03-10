using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform _pointA, _pointB;
    [SerializeField] private float _speed = 1f;

    private bool _movingPlatformSwitch = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_movingPlatformSwitch == false)
        {
            transform.position = Vector3.MoveTowards(
                transform.position, 
                _pointB.position, 
                _speed * Time.deltaTime
            );
        } 
        else if (_movingPlatformSwitch)
        {
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    _pointA.position,
                    _speed * Time.deltaTime
                );
            }
        }

        if (transform.position == _pointA.position)
        {
            _movingPlatformSwitch = false;
        }
        else if (transform.position == _pointB.position)
        {
            _movingPlatformSwitch = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
