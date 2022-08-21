using System;
using UnityEngine;


public class WhenNear : TorretRotationInterface
{
    private float _rotationTime = 10;
  
    public Quaternion TorretRotation(Vector3 playerPos, Transform torretTrans, float changeRangeOnRotation)
    {
       
            Quaternion startRot = torretTrans.rotation;
            Quaternion temp = startRot * Quaternion.AngleAxis(Time.deltaTime / _rotationTime * 360f, Vector3.up);
            return new Quaternion(0, temp.y, temp.z, temp.w);
        }
       
    }

