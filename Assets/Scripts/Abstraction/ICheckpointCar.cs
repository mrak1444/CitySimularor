using UnityEngine;
using UnityEngine.UI;

public interface ICheckpointCar
{
    Vector3 CheckpointCarPosition { get; }
    int NextCheckpointCar();
    bool FlagStop(ICar unite);
    Text TXT { get; set; }
}