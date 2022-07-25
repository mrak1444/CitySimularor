using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCheckpointController
{
    private List<ICar> _cars;
    private AllCheckpointsCarModel _allCheckpointsCarModel;

    public CarCheckpointController(List<ICar> cars, AllCheckpointsCarModel allCheckpointsCarModel)
    {
        _cars = cars;
        _allCheckpointsCarModel = allCheckpointsCarModel;
    }

    public void Checking()
    {
        if (_cars == null)
        {
            return;
        }
        foreach (var car in _cars)
        {
            var un = _allCheckpointsCarModel.Checkpoints[car.nextPosition];

            if (car.carPosition.x >= un.CheckpointCarPosition.x - 1 && car.carPosition.x <= un.CheckpointCarPosition.x + 1 && car.carPosition.z >= un.CheckpointCarPosition.z - 1 && car.carPosition.z <= un.CheckpointCarPosition.z + 1)
            {
                car.nextPosition = un.NextCheckpointCar();
                car.StopCarCrossroad = un.FlagStop(car);
                car.CheckpointCarTransformPosition = _allCheckpointsCarModel.Checkpoints[car.nextPosition].CheckpointCarPosition;
            }
        }
    }
}