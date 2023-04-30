using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private int _damageValue = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody && collision.rigidbody.GetComponent<PlayerHealth>() is PlayerHealth player)
        {
            player.TakeDamage(_damageValue);
        }
    }
}
