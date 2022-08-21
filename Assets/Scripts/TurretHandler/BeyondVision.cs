using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeyondVision : TorretRotationInterface
{
   
    public Quaternion TorretRotation(Vector3 playerPos, Transform torretTrans, float changeRangeOnRotation)
    {
        return Quaternion.identity;
    }
}
