using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f;
    [SerializeField] private float _speedGainPerSecond = 0.01f;
    [SerializeField] private float _turnSpeed = 200f;
    [SerializeField] private int _steerValue=0;
    void Start()
    {
        InvokeRepeating("IncreaseSpeed",5,5);
    }

    void FixedUpdate()
    {

        transform.Rotate(0, _steerValue* _turnSpeed * Time.deltaTime, 0);
        transform.Translate(Vector3.forward*_speed*Time.deltaTime* _speedGainPerSecond);
    }

    private void IncreaseSpeed()
    {
        _speedGainPerSecond += _speedGainPerSecond;
    }

    public void Steer(int value)
    {
        _steerValue = value;
    }
}
