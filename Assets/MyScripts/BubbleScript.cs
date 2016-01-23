using UnityEngine;
using System.Collections;

public class BubbleScript : MonoBehaviour {

	public float lifetime;
	public float lifetimeDelta;


	private float dieTime;

	private float sideFrequency;
	private float sideAmplitude;

	// Use this for initialization
	void Start () {
		dieTime = Time.time + lifetime + lifetimeDelta * (Random.value - 0.5f) * 2;
		RandomizeScale ();

		sideFrequency = 0.2f + Random.value * 0.2f;
		sideAmplitude = 0.002f + Random.value * 0.002f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= dieTime)
			Destroy (gameObject);
		else {
			MoveSideways ();
			FloatUp ();
		}
	}

	void MoveSideways () {

		// 2πf
		float fp2 = 2 * Mathf.PI * sideFrequency;

		// derivative of amplitude * sin(2πft)
		float x = fp2 * sideAmplitude * Mathf.Cos (fp2 * Time.time);

		transform.Translate (x, 0, 0);
	}

	void FloatUp () {
		transform.Translate (0, 0.03f, 0);
	}

	void RandomizeScale () {
		float factor = 0.8f + Random.value * 0.4f;

		transform.localScale *= factor;
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.gameObject.name == "Player") {
			// Apply upward force

			col.transform.GetComponent<Rigidbody2D> ().AddForce(new Vector3(0, 4, 0));


		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.name == "Player" && Random.value < 0.3) {
			// If touched player, 30% chance to increase player's bubble amount
			
			col.transform.GetComponent<FloatScript>().bubbles++;
			Destroy (gameObject);
		}
	}

	
}
