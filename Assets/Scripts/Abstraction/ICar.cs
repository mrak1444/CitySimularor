using UnityEngine;

public interface ICar
{
    Vector3 carPosition { get; }
    int nextPosition { get; set; }
    bool StopCarCrossroad { get; set; }
    bool StopCarObstacle { get; set; }
    Vector3 CheckpointCarTransformPosition { get; set; }
}