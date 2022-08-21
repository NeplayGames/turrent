using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeyondVision : TorretRotationInterface
{
    public event Action<DetermineDistance.PlayerState> SetInitialInfoOnLazer;

    public BeyondVision(DetermineDistance.PlayerState _playerState)
    {
        if (SetInitialInfoOnLazer != null)
            SetInitialInfoOnLazer(_playerState);
    }

    public Quaternion TorretRotation(Vector3 playerPos, Transform torretTrans, float changeRangeOnRotation)
    {
        return Quaternion.identity;
    }
}
