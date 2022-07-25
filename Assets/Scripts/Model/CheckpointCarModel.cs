using UnityEngine;
using UnityEngine.UI;

public class CheckpointCarModel : MonoBehaviour, ICheckpointCar
{
    [SerializeField] private int[] _checkpointsCar;
    [SerializeField] private CrossroadController _crossroadController;
    [SerializeField] private bool _stopcar = false;
    [SerializeField] private Text _text;

    private System.Random _rnd = new System.Random();

    public Text TXT { get => _text;  set => _text = value; }

    public Vector3 CheckpointCarPosition => transform.position;

    public bool FlagStop(ICar car)
    {
        if (_stopcar)
        {
            _crossroadController.AddCarToQueue(car);
        }
        
        return _stopcar;
        
    }

    public int NextCheckpointCar()
    {
        if (_checkpointsCar.Length > 1)
        {
            return _checkpointsCar[_rnd.Next(_checkpointsCar.Length)];
        }
        else
        {
            return _checkpointsCar[0];
        }
    }
}
