using System.Collections.Generic;
using UnityEngine;

public class CityController : MonoBehaviour
{
    [SerializeField] private GameObject[] _unitsGameObject;
    [SerializeField] private AllCheckpointsModel _allCheckpointsModel;

    private UniteCheckpointController uniteCheckpointController;
    private List<IUnite> _units = new List<IUnite>();

    void Start()
    {
        uniteCheckpointController = new UniteCheckpointController(_units, _allCheckpointsModel);

        foreach (var unite in _unitsGameObject)
        {
            _units.Add(unite.GetComponent<IUnite>());
        }
    }

    void Update()
    {
        uniteCheckpointController.Checking();
    }
}
