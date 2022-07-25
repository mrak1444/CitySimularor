using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCheckpointsCarModel : MonoBehaviour
{
    [SerializeField] private GameObject[] _checkpointsCar;
    private Dictionary<int, ICheckpointCar> checkpointsCar = new Dictionary<int, ICheckpointCar>();

    public Dictionary<int, ICheckpointCar> Checkpoints => checkpointsCar;

    private void Start()
    {
        for (int i = 1; i <= _checkpointsCar.Length; i++)
        {
            checkpointsCar.Add(i, _checkpointsCar[i - 1].GetComponent<ICheckpointCar>());
            checkpointsCar[i].TXT.text = i.ToString();
        }
    }
}