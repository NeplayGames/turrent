using System;
using UnityEngine;
public interface TorretRotationInterface
{
    Quaternion TorretRotation(Vector3 playerPos, Transform torretTrans, float changeRangeOnRotation);
}
