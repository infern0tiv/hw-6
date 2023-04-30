using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private bool _dieOnAnyCollision;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.attachedRigidbody && collider.attachedRigidbody.GetComponent<Bullet>())
        {
            _enemyHealth.TakeDamage(1);
        }
        if (_dieOnAnyCollision)
        {
            _enemyHealth.TakeDamage(int.MaxValue);
        }
    }
}
