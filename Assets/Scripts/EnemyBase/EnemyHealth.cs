using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health = 1;

    public UnityEvent EventOnTakeDamage;

    public void TakeDamage(int damageValue)
    {
        _health -= damageValue;

        if(_health <= 0)
        {
            Die();
            return;
        }

        EventOnTakeDamage.Invoke();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
