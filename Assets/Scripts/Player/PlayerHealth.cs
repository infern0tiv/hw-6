using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health = 5; public int Health => _health;
    [SerializeField] private int _maxHealth = 8; public int MaxHealth => _maxHealth;
    [SerializeField] private AudioSource _addHealth;
    [SerializeField] private HealthUI _healthUI;

    private bool _invulnerable = false;

    public UnityEvent EventOnTakeDamage;

    private void Start()
    {
        _healthUI.Setup(_maxHealth);
        _healthUI.DisplayHealth(_health);
    }

    public void TakeDamage(int damageValue)
    {
        if(!_invulnerable)
        {
            _health -= damageValue;
            if (_health <= 0)
            {
                _health = 0;
                Die();
            }
            _healthUI.DisplayHealth(_health);
            _invulnerable = true;
            Invoke(nameof(StopInvulnerable), 1f);

            EventOnTakeDamage.Invoke();
        }
    }

    public void AddHealth(int healthValue)
    {
        _health += healthValue;
        if (_health > _maxHealth) _health = _maxHealth;
        _addHealth.Play();
        _healthUI.DisplayHealth(_health);
    }

    private void Die()
    {
        Debug.Log("You Lose");
    }

    private void StopInvulnerable()
    {
        _invulnerable = false;
    }
}
