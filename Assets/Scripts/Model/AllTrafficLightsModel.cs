using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class AllTrafficLightsModel : MonoBehaviour
{
    [SerializeField] private GameObject[] _trafficLightsGameObject;
    [SerializeField] Text text;

    private List<ITrafficLight> _trafficLights = new List<ITrafficLight>();

    

    private void Start()
    {
        foreach(var TrLi in _trafficLightsGameObject)
        {
            _trafficLights.Add(TrLi.GetComponent<ITrafficLight>());
        }
        StartTimerTrafficLight();
    }

    private void StartTimerTrafficLight()
    {
        foreach(var TrLi in _trafficLights)
        {
            StartCoroutine(TimerTrafficLight(TrLi));
        }
    }

    IEnumerator TimerTrafficLight(ITrafficLight TrLi)   //  поработать с таймерами со всеми и куратинами
    {
        while (true)
        {
            yield return new WaitForSeconds(TrLi.TimeTrafficLight);
            if (!TrLi.StopTrafficLightUnite)
            {
                TrLi.StopTrafficLightUnite = !TrLi.StopTrafficLightUnite;
                text.text = $"Unite - {TrLi.StopTrafficLightUnite} | Car - {TrLi.StopTrafficLightCar}";
                if (TrLi.StopTrafficLightUnite == false) TrLi.EventStopUnite();
                yield return new WaitForSeconds(4f);
                TrLi.StopTrafficLightCar = !TrLi.StopTrafficLightCar;
                TrLi.EventStopCar();
                text.text = $"Unite - {TrLi.StopTrafficLightUnite} | Car - {TrLi.StopTrafficLightCar}";
            }
            else
            {
                TrLi.StopTrafficLightCar = !TrLi.StopTrafficLightCar;
                TrLi.EventStopCar();
                text.text = $"Unite - {TrLi.StopTrafficLightUnite} | Car - {TrLi.StopTrafficLightCar}";
                yield return new WaitForSeconds(4f);
                TrLi.StopTrafficLightUnite = !TrLi.StopTrafficLightUnite;
                text.text = $"Unite - {TrLi.StopTrafficLightUnite} | Car - {TrLi.StopTrafficLightCar}";
                if (TrLi.StopTrafficLightUnite == false) TrLi.EventStopUnite();
            }
        }
    }
}
