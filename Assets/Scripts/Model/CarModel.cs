using UnityEngine;

public class CarModel : MonoBehaviour, ICar
{
    [SerializeField] private Transform _firstCheckpointCarTransform;
    [SerializeField] private int _firstIdCheckpointCar;
    [SerializeField] private WheelCollider _leftWheel;
    [SerializeField] private WheelCollider _rightWheel;
    [SerializeField] private float _maxSteeringAngle;

    private int _nextPosition;
    private bool _isStopedCrossroad = false;
    private bool _isStopedObstacle = false;
    private float steering;
    private float motor;
    private float brake;
    public Vector3 _checkpointCarTransformPosition;

    public Vector3 carPosition => transform.position;
    public int nextPosition { get => _nextPosition; set => _nextPosition = value; }
    public bool StopCarCrossroad { get => _isStopedCrossroad; set => _isStopedCrossroad = value; }
    public bool StopCarObstacle { get => _isStopedObstacle; set => _isStopedObstacle = value; }
    public Vector3 CheckpointCarTransformPosition { get => _checkpointCarTransformPosition; set => _checkpointCarTransformPosition = value; }

    private void Start()
    {
        _checkpointCarTransformPosition = _firstCheckpointCarTransform.position;
        _nextPosition = _firstIdCheckpointCar;
    }

    private void Update()
    {
        var vectorCarPoint = CheckpointCarTransformPosition - transform.position;
        float angleForward = Vector3.Angle(vectorCarPoint, transform.forward);
        float angleRight = Vector3.Angle(vectorCarPoint, transform.right);

        if (angleRight > 90) angleForward = -angleForward;

        if (angleForward > _maxSteeringAngle) steering = _maxSteeringAngle;
        else if (angleForward < -_maxSteeringAngle) steering = -_maxSteeringAngle;
        else steering = angleForward;

        if (vectorCarPoint.magnitude > 2f && !_isStopedCrossroad && !_isStopedObstacle)
        {
            motor = 200;
            brake = 0;
        }

        if (vectorCarPoint.magnitude <= 2 && vectorCarPoint.magnitude >= 0.5f && !_isStopedCrossroad && !_isStopedObstacle)
        {
            motor = 50;
            brake = 25;
        }

        if (vectorCarPoint.magnitude <= 0.5f)
        {
            motor = 0;
            brake = 1000;
        }

        if (_isStopedCrossroad || _isStopedObstacle)
        {
            motor = 0;
            brake = 1000;
        }

        if (_leftWheel.rpm >= 80 || _rightWheel.rpm >= 80)
        {
            motor = 0;
            brake = 50;
        }

        _leftWheel.steerAngle = steering;
        _rightWheel.steerAngle = steering;

        _leftWheel.brakeTorque = brake;
        _rightWheel.brakeTorque = brake;

        _leftWheel.motorTorque = motor;
        _rightWheel.motorTorque = motor;
    }
}
