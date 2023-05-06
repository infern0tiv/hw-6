using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right
}

public class Walker : MonoBehaviour
{
    [SerializeField] private Transform _leftTarget;
    [SerializeField] private Transform _rightTarget;
    [SerializeField] private Transform _rayStart;

    [SerializeField] private float _speed;
    [SerializeField] private float _stopTime;
    [SerializeField] private Direction _currentDirection;

    private bool _isStopped;

    public UnityEvent OnLeftTarget;
    public UnityEvent OnRightTarget;

    private void Start()
    {
        _leftTarget.parent = null;
        _rightTarget.parent = null;
    }

    private void Update()
    {
        if (_isStopped) return;

        if(_currentDirection == Direction.Left)
        {
            transform.position -= new Vector3(Time.deltaTime * _speed, 0, 0);
            if (transform.position.x < _leftTarget.position.x)
            {
                _currentDirection = Direction.Right;
                _isStopped = true;
                OnLeftTarget.Invoke();
                Invoke(nameof(ContinueWalk), _stopTime);
            }
        } else
        {
            transform.position += new Vector3(Time.deltaTime * _speed, 0, 0);
            if (transform.position.x > _rightTarget.position.x)
            {
                _currentDirection = Direction.Left;
                _isStopped = true;
                OnRightTarget.Invoke();
                Invoke(nameof(ContinueWalk), _stopTime);
            }
        }

        RaycastHit hit;
        if(Physics.Raycast(_rayStart.position, Vector3.down, out hit))
        {
            transform.position = hit.point;
        }
    }

    private void ContinueWalk()
    {
        _isStopped = false;
    }

}
