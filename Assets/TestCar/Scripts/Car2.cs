using UnityEngine;

public class Car2 : MonoBehaviour
{
    [SerializeField] private GameObject _point1;
    [SerializeField] private GameObject _point2;
    [SerializeField] private WheelCollider _leftWheel;
    [SerializeField] private WheelCollider _rightWheel;
    [SerializeField] private float _maxSteeringAngle;
     
    private float steering;
    private float motor;
    private float brake;
    private GameObject _point;

    private void Start()
    {
        _point = _point1;
    }

    private void FixedUpdate()
    {
        var vectorCarPoint = _point.transform.position - transform.position;
        float angleForward = Vector3.Angle(vectorCarPoint, transform.forward);
        float angleRight = Vector3.Angle(vectorCarPoint, transform.right);

        if (angleRight > 90) angleForward = -angleForward;

        if (angleForward > _maxSteeringAngle) steering = _maxSteeringAngle;
        else if (angleForward < -_maxSteeringAngle) steering = -_maxSteeringAngle;
        else steering = angleForward;

        if (vectorCarPoint.magnitude > 2f)
        {
            motor = 50;
            brake = 0;
        }

        if (vectorCarPoint.magnitude <= 2 && vectorCarPoint.magnitude >= 0.5f) // && Mathf.Abs(angleForward) < 30)
        {
            motor = 50;
            brake = 25;
        }

        /*if (vectorCarPoint.magnitude <= 2 && vectorCarPoint.magnitude >= 0.5f && Mathf.Abs(angleForward) > 30)
        {
            motor = -100;
            brake = 0;
            steering = -steering;
        }*/

        if (vectorCarPoint.magnitude <= 0.5f)
        {
            motor = 0;
            brake = 1000;
            _point = _point2;
        }

        _leftWheel.steerAngle = steering;
        _rightWheel.steerAngle = steering;

        _leftWheel.brakeTorque = brake;
        _rightWheel.brakeTorque = brake;

        _leftWheel.motorTorque = motor;
        _rightWheel.motorTorque = motor;
    }
}
