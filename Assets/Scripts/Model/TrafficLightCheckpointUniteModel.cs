using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightCheckpointUniteModel : MonoBehaviour, ICheckpoint
{
    [SerializeField] private int[] _checkpoints;
    [SerializeField] private GameObject _TL;

    private ITrafficLight _trafficLight;
    private System.Random _rnd = new System.Random();
    private int num;
    private List<IUnite> _unitesStop = new List<IUnite>();

    public Vector3 CheckpointPosition => transform.position;

    private void Start()
    {
        _trafficLight = _TL.GetComponent<ITrafficLight>();
        _trafficLight.EventTrafficLightsUnite += EventTrafficLights;
    }

    private void EventTrafficLights()
    {
        if (_unitesStop.Count > 0)
        {
            for (int i = 0; i < _unitesStop.Count; i++)
            {
                _unitesStop[i].StopUnite = false;
            }
            _unitesStop.Clear();
        }
    }

    public bool FlagStop(IUnite unite, int numId)
    {
        if(numId == _checkpoints[0])
        {
            return false;
        }
        else
        {
            if (_trafficLight.StopTrafficLightUnite == false)
            {
                return false;
            }
            else
            {
                _unitesStop.Add(unite);
                return true;
            }
        }
    }

    public int NextCheckpoint(int numId)
    {
        if (_checkpoints.Length > 1)
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


