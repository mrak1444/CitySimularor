using System;

public interface ITrafficLight
{
    bool StopTrafficLightUnite { get; set; }
    bool StopTrafficLightCar { get; set; }
    float TimeTrafficLight { get; }

    event Action EventTrafficLightsUnite;
    void EventStopUnite();

    event Action<bool> EventTrafficLightsCar;
    void EventStopCar();
}
