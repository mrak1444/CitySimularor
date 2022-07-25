using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCheckpointsModel : MonoBehaviour
{
    [SerializeField] private GameObject[] _checkpoints;
    private Dictionary<int, ICheckpoint> checkpoints = new Dictionary<int, ICheckpoint>();

    public Dictionary<int, ICheckpoint> Checkpoints => checkpoints;

    private void Start()
    {
        for(int i = 1; i <= _checkpoints.Length; i++)
        {
            checkpoints.Add(i, _checkpoints[i-1].GetComponent<ICheckpoint>());
        }
    }
}
