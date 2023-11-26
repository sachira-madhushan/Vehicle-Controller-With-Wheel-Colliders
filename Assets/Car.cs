using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public WheelCollider backLeft, backRight, frontLeft, frontRight;
    public Transform backLeftTrans, backRightTrans, frontLeftTrans, frontRightTrans;

    float _angle = 25f;
    float _motorSpeed = 1000;

    float h, v;
    void Start()
    {
        
    }

    void Update()
    {
        h=Input.GetAxis("Horizontal");
        v=Input.GetAxis("Vertical");

        frontLeft.steerAngle = _angle * h;
        frontRight.steerAngle = _angle * h;
        Drive();
        UpdateWheel(backLeft,backLeftTrans);
        UpdateWheel(backRight,backRightTrans);
        UpdateWheel(frontLeft,frontLeftTrans);
        UpdateWheel(frontRight,frontRightTrans);
    }

    void Drive()
    {
        backLeft.motorTorque = _motorSpeed * v;
        backRight.motorTorque = _motorSpeed * v;
    }


    void UpdateWheel(WheelCollider col,Transform t)
    {
        Vector3 position = t.position;
        Quaternion rotation = t.rotation;

        col.GetWorldPose(out position,out rotation);

        t.position = position;
        t.rotation = rotation;
    }
}
