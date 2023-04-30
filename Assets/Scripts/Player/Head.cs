using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _aim;

    private void Update()
    {
        transform.position = _target.position;

        RotateHead();
    }

    private void RotateHead()
    {
        float angle = transform.position.x > _aim.position.x ? 40 : -40;
        Quaternion qr = Quaternion.Euler(new Vector3(0, angle, 0));
        transform.localRotation = Quaternion.Lerp(transform.rotation, qr, Time.deltaTime * 15);
    }
}
