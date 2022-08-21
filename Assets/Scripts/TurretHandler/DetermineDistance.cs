using UnityEngine;

public class DetermineDistance : MonoBehaviour
{
    [Header("Distance from player the turrent start to follow player")]
    [SerializeField] private int _startFarDistance;

    [Header("Distance after which the turrent starts to attack")]
    [SerializeField] private int _outOfRangeDistance = 20;
    [SerializeField] private TurretHandler _turretHandler;

    [Header("Layers mask to represent those object that blocks")]
    [SerializeField] private LayerMask _blockLayerMask;

    [SerializeField] LaserHandler laserHandler;

    private Transform _player;
    public enum PlayerState { far,near,cannotSeeState, }
    PlayerState _playerState,_tempPlayerState;

    private void Start()
    {
        
        _player = _turretHandler.GetPlayer();
        _playerState = DetermineState();
        ChangeState();
    }
    void Update()
    {
        PlayerState playerState = DetermineState();
        _playerState = playerState;
        if (_tempPlayerState != _playerState)
            ChangeState();    
    }

    private PlayerState DetermineState()
    {
        float distance = Vector3.Distance(_player.position, transform.position);
        bool blocked = Physics.Raycast(new Ray(transform.position, _player.position),_outOfRangeDistance,_blockLayerMask);
        if (distance>_outOfRangeDistance || blocked)
        {
            return PlayerState.cannotSeeState;
        }
        //This is called when the player is in visible state and checks if the player is in the distance
        // the turrent has to follow or to move in circular motion.
        //if(distance < _startFarDistance)
        //near
        //else
        //far
        return distance < _startFarDistance ? PlayerState.near : PlayerState.far;
    }

    private void ChangeState()
    {
        TorretRotationInterface torretRotationInterface;
        if (_playerState == PlayerState.far)        
            torretRotationInterface = new WhenFar(_playerState);
        else if (_playerState == PlayerState.near)        
          torretRotationInterface = new WhenNear(_playerState);       
        else       
            torretRotationInterface = new BeyondVision(_playerState);

        laserHandler.SetTorretRotationInterface(_playerState);
        _tempPlayerState = _playerState;
        _turretHandler.SetTorretRotation(torretRotationInterface);
    }
}
