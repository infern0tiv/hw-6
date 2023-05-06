using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _effectPrafab;

    private void Start()
    {
        Destroy(gameObject, 4);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Hit();
    }

    public void Hit()
    {
        Instantiate(_effectPrafab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
