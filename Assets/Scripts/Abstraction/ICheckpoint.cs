using UnityEngine;

public interface ICheckpoint
{
    Vector3 CheckpointPosition { get; }
    int NextCheckpoint(int numId);
    bool FlagStop(IUnite unite, int numId);
}
