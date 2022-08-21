using System;
using UnityEngine;

public class WhenFar : TorretRotationInterface
{
   
    public Quaternion TorretRotation(Vector3 playerPos,Transform torretTrans, float changeRangeOnRotation)
    {
        Vector3 direction = playerPos - torretTrans.position;
        Quaternion lookRotate = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(torretTrans.rotation, lookRotate, changeRangeOnRotation).eulerAngles;
        return Quaternion.Euler(0f, rotation.y, 0f);
    }

   
}
