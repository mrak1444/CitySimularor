using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossroadController : MonoBehaviour, ICrossroadController
{
    [SerializeField] private GameObject _TL;

    private ITrafficLight _trafficLight;
    private Queue<ICar> _queueCars = new Queue<ICar>();
    private bool _carIsStoped = false;

    public void AddCarToQueue(ICar car)
    {
        _queueCars.Enqueue(car);
    }

    private void Start()
    {
        if(_TL != null)
        {
            _trafficLight = _TL.GetComponent<ITrafficLight>();
            _trafficLight.EventTrafficLightsCar += EventCarRun;
        }
        StartCoroutine(QueueDequeue());
    }

    private void EventCarRun(bool flag)
    {
        _carIsStoped = flag;
    }

    IEnumerator QueueDequeue()
    {
        while (true)
        {
            if (_queueCars.Count != 0 && !_carIsStoped)
            {
                _queueCars.Dequeue().StopCarCrossroad = false;
            }
            yield return new WaitForSeconds(2f);
        }
    }
}
