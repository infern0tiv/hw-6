using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private bool _dieOnAnyCollision;

    private void OnCollisionEnter(Collision collision)
    {
        // почему collision.rigidbody, а не collision.gameObject ???
        if (collision.rigidbody && collision.rigidbody.GetComponent<Bullet>())
        {
            _enemyHealth.TakeDamage(1);
        }
        if(_dieOnAnyCollision)
        {
            _enemyHealth.TakeDamage(int.MaxValue);
        }
    }
}
