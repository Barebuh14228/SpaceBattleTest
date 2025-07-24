using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    [SerializeField] private Missile _missilePrefab;
    [SerializeField] private ParticleSystem _explosionPrefab;
    [Space] 
    [SerializeField] private float _moveSpeed;
    [SerializeField] private List<Vector3> _waypoints;

    private int _targetPositionIndex;

    public void LaunchMissile(UFO target)
    {
        Instantiate(_missilePrefab, transform.position, Quaternion.identity).Launch(target);
    }

    public void ApplyDamage()
    {
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity).Play();
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, _waypoints[_targetPositionIndex]) <= 0.05f)
        {
            _targetPositionIndex = (_targetPositionIndex + 1) % _waypoints.Count;
        }
        
        var targetPosition = _waypoints[_targetPositionIndex];
        var distance = Vector3.Distance(transform.position, targetPosition);
        
        transform.position = Vector3.Lerp(transform.position, targetPosition, _moveSpeed / distance);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetPosition), Time.deltaTime);
    }
}