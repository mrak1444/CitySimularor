using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightModel : MonoBehaviour, ITrafficLight
{
    [SerializeField] private float _timeTrafficLight;

    private bool _stopTrafficLightUnite = false;
    private bool _stopTrafficLightCar = true;

    public bool StopTrafficLightUnite { get => _stopTrafficLightUnite; set => _stopTrafficLightUnite = value; }
    public bool StopTrafficLightCar { get => _stopTrafficLightCar; set => _stopTrafficLightCar = value; }
    public float TimeTrafficLight { get => _timeTrafficLight; }

    public event Action EventTrafficLightsUnite;
    public event Action<bool> EventTrafficLightsCar;

    public void EventStopUnite()
    {
        EventTrafficLightsUnite?.Invoke();
    }

    public void EventStopCar()
    {
        EventTrafficLightsCar?.Invoke(_stopTrafficLightCar);
    }
}
