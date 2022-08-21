using UnityEngine;

public class TurretHandler : MonoBehaviour
{
    [SerializeField] private int _changeRangeOnRotation;
    [SerializeField] private Transform _player;
    private TorretRotationInterface _torretRotationInterface;
    public Transform GetPlayer()
    {
        return _player;
    }

    void Update()
    {
        RotateTowardsPlayer();
    }

    public void SetTorretRotation(TorretRotationInterface torretRotationInterface)
    {
        _torretRotationInterface = torretRotationInterface;
    }
    private void RotateTowardsPlayer()
    {
        transform.rotation = _torretRotationInterface.TorretRotation(_player.position, transform, _changeRangeOnRotation * Time.deltaTime);
    }
}
