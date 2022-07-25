using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointModel : MonoBehaviour, ICheckpoint
{
    [SerializeField] private int[] _checkpoints;

    private System.Random _rnd = new System.Random();
    private int num;

    public Vector3 CheckpointPosition => transform.position;

    public bool FlagStop(IUnite unite, int numId)
    {
        return false;
    }

    public int NextCheckpoint(int numId)
    {
        if(_checkpoints.Length > 1)
        {
            do
            {
                num = _checkpoints[_rnd.Next(_checkpoints.Length)];
            } while (num == numId);
        }
        else
        {
            num = _checkpoints[0];
        }
        
        return num;
    }
}
