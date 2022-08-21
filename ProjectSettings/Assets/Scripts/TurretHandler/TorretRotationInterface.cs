using System;
using UnityEngine;
public interface TorretRotationInterface
{
    public event Action<DetermineDistance.PlayerState> SetInitialInfoOnLazer;
    Quaternion TorretRotation(Vector3 playerPos, Transform torretTrans, float changeRangeOnRotation);
}
