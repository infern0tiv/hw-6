using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private bool _dieOnAnyCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if (_dieOnAnyCollision) _enemyHealth.TakeDamage(int.MaxValue);
        else if (collision.rigidbody && collision.rigidbody.GetComponent<Bullet>()) _enemyHealth.TakeDamage(1);
    }
}
