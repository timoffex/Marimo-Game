using UnityEngine;
using System.Collections;

public class FloatScript : MonoBehaviour {

	private float _bubbles = 0f;
	public float bubbles {
		get { return _bubbles; }
		set {
			_bubbles = value;
			bubbleSystem.emissionRate = value / 10;
		}
	}

	public float forceMaxRoll = 10f;
	public float forceMaxFloat = 10f;


	private ParticleSystem bubbleSystem;
	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		bubbleSystem = GetComponent<ParticleSystem> ();
	}

	// Update is called once per frame
	void Update () {

		float rollForce = forceMaxRoll * Input.GetAxis ("Horizontal");
		float upForce = bubbles * 0.2f + forceMaxFloat * Input.GetAxis ("Vertical");

		rigidBody.AddForce (new Vector2 (rollForce, upForce));
	}
}
