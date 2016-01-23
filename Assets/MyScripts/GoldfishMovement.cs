using UnityEngine;
using System.Collections;

public class GoldfishMovement : MonoBehaviour {

	public float maxForce;
	public float maxTorque;

	
	private Rigidbody2D rigidBody;



	private Vector2 target;


	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		target = transform.position;
	}

	void Update () {
		float distance = Vector3.Distance (transform.position, target);

		if (distance > 0.5) {
			MoveToTarget ();
			LookAtTarget ();
		}
	}

	void MoveToTarget () {
		Vector2 dif = GetToTarget ().normalized;
		Vector2 force = maxForce * dif;

		rigidBody.AddForce (force);
	}

	void LookAtTarget () {
		Vector2 toTarget = GetToTarget ().normalized;

		float angle = Vector2.Angle (transform.right, toTarget);
		float angularVelocity = rigidBody.angularVelocity;

		if (transform.right.x * toTarget.y > transform.right.y * toTarget.x)
			angle *= -1;

		Mathf.SmoothDamp (angle, 0, ref angularVelocity, 0.3f);


		float delta = angularVelocity - rigidBody.angularVelocity;
		float torque = rigidBody.inertia * delta;

		if (Mathf.Abs (torque) > maxTorque) {
			torque *= maxTorque / Mathf.Abs (torque);
		}

		rigidBody.AddTorque (torque);
	}

	Vector2 MyPosition () {
		return new Vector2 (transform.position.x, transform.position.y);
	}

	Vector2 GetToTarget () {
		return target - MyPosition ();
	}


	public void SetTarget (Vector3 pos) {
		target = new Vector2 (pos.x, pos.y);
	}

}
