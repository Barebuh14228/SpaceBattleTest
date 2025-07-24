using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    
    private UFO _target;
    
    private Vector3 TargetPosition => _target.transform.position;
    
    public void Launch(UFO target)
    {
        _target = target;
    }

    private void FixedUpdate()
    {
        if (!_target)
            return;
        
        var distance = Vector3.Distance(transform.position, TargetPosition);
        
        transform.position = Vector3.Lerp(transform.position, TargetPosition, _moveSpeed / distance);

        if (Vector3.Distance(transform.position,TargetPosition) <= 0.1f)
        {
            _target.ApplyDamage();
            Destroy(gameObject);
        }
    }
}