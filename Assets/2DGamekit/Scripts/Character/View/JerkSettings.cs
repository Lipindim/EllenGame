using UnityEngine;


[CreateAssetMenu(fileName = "Settings/Jerk Settings")]
public class JerkSettings : ScriptableObject
{
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _downSpeed;
    [SerializeField] private float _durationInSeconds;
    [SerializeField] private bool _upgraded = true;

    [SerializeField] private float _forwardSpeedUpgraded;
    [SerializeField] private float _extraUpForceOnHit;
    [SerializeField] private float _durationExtraUpForce;

    public float ForwardSpeed
    {
        get
        {
            if (_upgraded)
                return _forwardSpeedUpgraded;
            else
                return _forwardSpeed;
        }
    }
    public float DownSpeed => _downSpeed;
    public float DurationInSeconds => _durationInSeconds;
    public bool Upgraded => _upgraded;
    public float ExtraUpForceOnHit => _extraUpForceOnHit;
    public float DurationExtraUpForce => _durationExtraUpForce;
}

