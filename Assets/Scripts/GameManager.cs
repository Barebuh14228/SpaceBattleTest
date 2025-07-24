using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UFO _playerUFO;
    [SerializeField] private UFO _targetUFO;

    private bool _missileLaunched;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !_missileLaunched)
        {
            _playerUFO.LaunchMissile(_targetUFO);
            _missileLaunched = true;
        }
    }
}
