using System;
using UnityEngine;

public class WhenFar : TorretRotationInterface
{
    public event Action<DetermineDistance.PlayerState> SetInitialInfoOnLazer;
    public WhenFar(DetermineDistance.PlayerState p)
    {
        if(SetInitialInfoOnLazer != null)
            SetInitialInfoOnLazer(p);
    }
    public Quaternion TorretRotation(Vector3 playerPos,Transform torretTrans, float changeRangeOnRotation)
    {
        Vector3 direction = playerPos - torretTrans.position;
        Quaternion lookRotate = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(torretTrans.rotation, lookRotate, changeRangeOnRotation).eulerAngles;
        return Quaternion.Euler(0f, rotation.y, 0f);
    }

   
}
