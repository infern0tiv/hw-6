using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private bool _dieOnAnyCollision;

    private void OnTriggerEnter(Collider collider)
    {
        if (_dieOnAnyCollision && !collider.isTrigger) _enemyHealth.TakeDamage(int.MaxValue);
        else if (collider.attachedRigidbody && collider.attachedRigidbody.GetComponent<Bullet>() is Bullet bullet)
        {
            _enemyHealth.TakeDamage(1);
            bullet.Hit();
        }
    }
}
