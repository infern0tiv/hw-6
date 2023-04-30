using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	[SerializeField] private Rigidbody _rigidbody;
	[SerializeField] private float _moveSpeed = 1;
	[SerializeField] private float _jumpSpeed = 1;
	[SerializeField] private float _friction = 1;
	[SerializeField] private float _maxSpeed = 1;
	[SerializeField] private Transform ColliderTransform;

	private bool _grounded;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (_grounded) _rigidbody.AddForce(0f, _jumpSpeed, 0f, ForceMode.VelocityChange);
		}

		if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || !_grounded)
		{
			ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * 15f);
		}
		else
		{
			ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, Vector3.one, Time.deltaTime * 15f);
		}
	}

	private void FixedUpdate()
	{
		float speedMultiplier = 1f;

		if (!_grounded)
		{
			speedMultiplier = 0.2f;

            if (_rigidbody.velocity.x > _maxSpeed && Input.GetAxis("Horizontal") > 0) speedMultiplier = 0;
            if (_rigidbody.velocity.x < -_maxSpeed && Input.GetAxis("Horizontal") < 0) speedMultiplier = 0;
        }

		_rigidbody.AddForce(Input.GetAxis("Horizontal") * _moveSpeed * speedMultiplier, 0f, 0f, ForceMode.VelocityChange);
		if (_grounded) _rigidbody.AddForce(-_rigidbody.velocity.x * _friction, 0f, 0f, ForceMode.VelocityChange);
	}

	private void OnCollisionStay(Collision collision)
	{
		float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);
		if (angle < 45) _grounded = true;
	}

	private void OnCollisionExit(Collision collision)
	{
		_grounded = false;
	}
}
