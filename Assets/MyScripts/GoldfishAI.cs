using UnityEngine;
using System.Collections;

public class GoldfishAI : MonoBehaviour {

	private GoldfishMovement mover;

	// Use this for initialization
	void Start () {
		mover = GetComponent<GoldfishMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		mover.SetTarget (GameObject.Find ("Player").transform.position);


		OrientSelf ();
	}

	void OrientSelf () {
		if (transform.up.y < 0) {
			transform.Rotate (new Vector3 (0, 180, 0));
			transform.Rotate (new Vector3 (0, 0, 180));
		}
	}
}
