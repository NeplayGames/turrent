using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHandler : MonoBehaviour
{
    [SerializeField] private float time = 5;
    [SerializeField] private LineRenderer lineRenderer;
    [Header("Percentage defining change in state when it is near")]
    [SerializeField] private int _percentage;

    [Header("Initial angle of lazer")]
    [SerializeField] private int _initialAngle = 30;
  
   public void SetTorretRotationInterface(DetermineDistance.PlayerState playerState)
    {
       TorretRotationInterface_SetInitialInfoOnLazer(playerState);
    }

    private void TorretRotationInterface_SetInitialInfoOnLazer(DetermineDistance.PlayerState obj)
    {
        switch (obj) {
            case DetermineDistance.PlayerState.near:
                WhenNear_forLeasureAngleChange();
                break;
            case DetermineDistance.PlayerState.far:
                WhenFar_forFarChange();
                break;
            case DetermineDistance.PlayerState.cannotSeeState:
                BeyondVision_DisableLaser();
                break;
        }

    }

    private void BeyondVision_DisableLaser()
    {
        Vector3[] pos = { Vector3.zero, Vector3.zero };
        SetLeserPosition(pos);
    }

    private void SetLeserPosition(Vector3[] pos)
    {
        lineRenderer.SetPositions(pos);
    }

    private void WhenFar_forFarChange()
    {
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        StopAllCoroutines();
        Vector3[] pos = { Vector3.zero, new Vector3(0, 0, 100) };
        SetLeserPosition(pos);
    }

    private void WhenNear_forLeasureAngleChange()
    {
        transform.localRotation = Quaternion.Euler(0, -_initialAngle,  0);
        StartCoroutine(ChangeDirection(_initialAngle ,_percentage));
        Vector3[] pos = { Vector3.zero, new Vector3(0,0,100) };
        SetLeserPosition(pos);
    }

    IEnumerator ChangeDirection(int angle,int percentage)
    {
        yield return new WaitForSeconds((percentage / 100f) * time);
        transform.localRotation = Quaternion.Euler(0, -(angle -3), 0);
        if(angle>0)
        StartCoroutine(ChangeDirection(angle > 0?angle -3:0,percentage));
       else
            StartCoroutine(ChangeDirection(_initialAngle, percentage));
    }
}
