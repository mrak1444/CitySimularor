using UnityEngine;
using UnityEngine.AI;

public class UniteModel : MonoBehaviour, IUnite
{
    [SerializeField] private Transform _firstCheckpointTransform;
    [SerializeField] private int _firstIdCheckpoint;

    private NavMeshAgent _meshUnite;
    private int _previousPosition = 0;
    private int _nextPosition;
    private bool _isStoped = false;

    public Vector3 unitePosition => transform.position;
    public NavMeshAgent navMeshUnite => _meshUnite;
    public int previousPosition { get => _previousPosition; set => _previousPosition = value; }
    public int nextPosition { get => _nextPosition; set => _nextPosition = value; }
    public bool StopUnite { get => _isStoped; set => _isStoped = value; }

    private void Start()
    {
        _meshUnite = GetComponent<NavMeshAgent>();
        _nextPosition = _firstIdCheckpoint;
        _meshUnite.destination = _firstCheckpointTransform.position;
    }

    private void Update()
    {
        _meshUnite.isStopped = _isStoped;
    }
}
