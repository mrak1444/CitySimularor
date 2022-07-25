using System.Collections.Generic;
using UnityEngine;

public class CityController2 : MonoBehaviour
{
    [SerializeField] private GameObject[] _carGameObject;
    [SerializeField] private AllCheckpointsCarModel _allCheckpointsCarModel;

    private CarCheckpointController carCheckpointController;
    private SearchObstaclesController _searchObstaclesController;
    private List<ICar> _car = new List<ICar>();

    void Start()
    {
        carCheckpointController = new CarCheckpointController(_car, _allCheckpointsCarModel);
        _searchObstaclesController = new SearchObstaclesController(_car);

        foreach (var car in _carGameObject)
        {
            _car.Add(car.GetComponent<ICar>());
        }
    }

    void Update()
    {
        carCheckpointController.Checking();
        _searchObstaclesController.Checking();
    }
}
