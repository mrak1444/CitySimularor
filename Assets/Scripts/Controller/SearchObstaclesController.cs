using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchObstaclesController
{
    private List<ICar> _cars;
    public SearchObstaclesController(List<ICar> cars)
    {
        _cars = cars;
    }

    public void Checking()
    {
        if (_cars == null)
        {
            return;
        }
        foreach (var car in _cars)
        {
            RaycastHit hit;
            if (Physics.Raycast(car.carPosition, car.CheckpointCarTransformPosition - car.carPosition, out hit, 4f))
            {
                car.StopCarObstacle = true;
                //Debug.Log($"{hit.collider.gameObject.name}");
            }
            else
            {
                car.StopCarObstacle = false;
            }
            //Debug.DrawRay(car.carPosition, car.CheckpointCarTransformPosition - car.carPosition, Color.yellow);
        }
    }
}
