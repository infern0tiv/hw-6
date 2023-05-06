using UnityEngine;

public class Hen : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _maxSpeed = 3f;
    [SerializeField] private float _timeToReachSpeed = 2f;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void FixedUpdate()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = _rigidbody.mass * (toPlayer * _maxSpeed - _rigidbody.velocity) / _timeToReachSpeed;

        _rigidbody.AddForce(force);
    }
}
