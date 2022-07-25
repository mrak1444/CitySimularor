using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniteCheckpointController
{
    private List<IUnite> _unite;
    private AllCheckpointsModel _allCheckpointsModel;

    public UniteCheckpointController(List<IUnite> unite, AllCheckpointsModel allCheckpointsModel)
    {
        _unite = unite;
        _allCheckpointsModel = allCheckpointsModel;
    }

    public void Checking()
    {
        if (_unite == null)
        {
            return;
        }
        foreach (var unite in _unite)
        {
            var un =_allCheckpointsModel.Checkpoints[unite.nextPosition];

            if (unite.unitePosition.x >= un.CheckpointPosition.x - 1 && unite.unitePosition.x <= un.CheckpointPosition.x + 1 && unite.unitePosition.z >= un.CheckpointPosition.z - 1 && unite.unitePosition.z <= un.CheckpointPosition.z + 1)
            {
                var newPosition = un.NextCheckpoint(unite.previousPosition);
                unite.StopUnite = un.FlagStop(unite, unite.previousPosition);
                unite.previousPosition = unite.nextPosition;
                unite.nextPosition = newPosition;
                unite.navMeshUnite.destination = _allCheckpointsModel.Checkpoints[newPosition].CheckpointPosition;
            }
        }
    }
}
