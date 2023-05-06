using System.Collections.Generic;
using UnityEngine;

public class EnemyActivator : MonoBehaviour
{
    [SerializeField] private Transform _targetActivator;
    [SerializeField] private List<GameObject> _enemies = new List<GameObject>();
    [SerializeField] private float _distanceActivate = 20f;

    private void Start()
    {
        for (int i = 0; i < _enemies.Count; i++) _enemies[i].SetActive(false);
    }

    private void Update()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            float distance = Vector3.Distance(_targetActivator.position, _enemies[i].transform.position);
            if (distance < _distanceActivate)
            {
                _enemies[i].SetActive(true);
                _enemies.RemoveAt(i);
            }
        }
    }
}
