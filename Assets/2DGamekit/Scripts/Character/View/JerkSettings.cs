using UnityEngine;


[CreateAssetMenu(fileName = "Settings/Jerk Settings")]
public class JerkSettings : ScriptableObject
{
    [SerializeField] private float _directForce;
    [SerializeField] private float _upForce;
    [SerializeField] private float _durationInSeconds;

    public float DirectForce => _directForce;
    public float UpForce => _upForce;
    public float DurationInSeconds => _durationInSeconds;
}

