using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject _healthIconPrefab;

    private List<GameObject> _healthIcons = new List<GameObject>();

    public void Setup(int maxHealth)
    {
        for(int i = 0; i < maxHealth; i++)
        {
            GameObject healthIcon = Instantiate(_healthIconPrefab, transform);
            _healthIcons.Add(healthIcon);
        }
    }

    public void DisplayHealth(int health)
    {
        for(int i = 0; i < _healthIcons.Count; i++)
        {
            _healthIcons[i].SetActive(i < health);
        }
    }
}
