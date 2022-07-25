using UnityEngine;
using UnityEngine.AI;

public interface IUnite
{
    Vector3 unitePosition { get; }
    NavMeshAgent navMeshUnite { get; }
    int previousPosition { get; set; }
    int nextPosition { get; set; }
    bool StopUnite { get; set; }
}
