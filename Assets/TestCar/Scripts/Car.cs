using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Car : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;

    [SerializeField] private GameObject _point;

    public void FixedUpdate()
    {
        //float motor = maxMotorTorque * Input.GetAxis("Vertical");
        //float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        float steering;
        float motor = 0;
        float brake = 400;

        var vectorCarPoint = _point.transform.position - transform.position; 
        float angle1 = Vector3.Angle(vectorCarPoint, transform.forward);
        float angle2 = Vector3.Angle(vectorCarPoint, transform.right);

        if(angle2 > 90) angle1 = -angle1;

        if (angle1 > 30) steering = 30;
        else if (angle1 < -30) steering = -30;
        else steering = angle1;

        if (vectorCarPoint.magnitude > 2f)
        {
            motor = 100;
            brake = 0;
        }

        /*if(vectorCarPoint.magnitude <= 2 && Mathf.Abs(angle1) > 30)
        {
            motor = -100;
            brake = 0;
            steering = -steering;
        }*/

        

        foreach (AxleInfo axleInfo in axleInfos)
        {
            Debug.Log($"brake = {brake}, motor = {motor}");

            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                if (vectorCarPoint.magnitude <= 2f && vectorCarPoint.magnitude > 0.5f && axleInfo.leftWheel.rpm >=20)
                {
                    motor = 0;
                    brake = 300;
                }
                else if (vectorCarPoint.magnitude <= 2f && vectorCarPoint.magnitude > 0.5f && axleInfo.leftWheel.rpm < 20)
                {
                    motor = 100;
                    brake = 0;
                }

                axleInfo.leftWheel.brakeTorque = brake;
                axleInfo.rightWheel.brakeTorque = brake;

                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
        }
    }
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}