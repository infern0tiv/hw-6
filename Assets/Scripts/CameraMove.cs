using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        transform.position = new Vector3(_target.position.x, _target.position.y, -10);
    }
}
