using UnityEngine;

public class MakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private int _damageValue = 1;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.attachedRigidbody && collider.attachedRigidbody.GetComponent<PlayerHealth>() is PlayerHealth player)
        {
            player.TakeDamage(_damageValue);
        }
    }
}
