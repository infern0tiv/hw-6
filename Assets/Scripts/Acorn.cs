using UnityEngine;

public class Acorn : MonoBehaviour
{
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private float _maxRotationSpeed;

    private void Start()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.AddRelativeForce(_velocity, ForceMode.VelocityChange);
        rb.angularVelocity = new Vector3(GetRandomRotationSpeed(), GetRandomRotationSpeed(), GetRandomRotationSpeed());
    }

    private float GetRandomRotationSpeed()
    {
        return Random.Range(-_maxRotationSpeed, _maxRotationSpeed);
    }
}
