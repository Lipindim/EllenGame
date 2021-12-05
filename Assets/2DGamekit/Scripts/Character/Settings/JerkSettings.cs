using UnityEngine;


[CreateAssetMenu(fileName = "Settings/Jerk Settings")]
public class JerkSettings : ScriptableObject
{
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _downSpeed;
    [SerializeField] private float _durationInSeconds;

    [SerializeField] private float _forwardSpeedUpgraded;
    [SerializeField] private float _extraUpForceOnHit;
    [SerializeField] private float _durationExtraUpForce;


    public float ForwardSpeed
    {
        get
        {
            if (Upgraded)
                return _forwardSpeedUpgraded;
            else
                return _forwardSpeed;
        }
    }
    public float DownSpeed => _downSpeed;
    public float DurationInSeconds => _durationInSeconds;
    public bool Upgraded { get; private set; } = false;
    public float ExtraUpForceOnHit => _extraUpForceOnHit;
    public float DurationExtraUpForce => _durationExtraUpForce;

    public void ResetUpgrade()
    {
        Upgraded = false;
    }

    public void Upgrade()
    {
        Upgraded = true;
    }

}

