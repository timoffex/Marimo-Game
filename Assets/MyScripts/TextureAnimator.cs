using UnityEngine;
using System.Collections;

public class TextureAnimator : MonoBehaviour {

	public Sprite[] textures;
	public float timePerTexture;


	private int index;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		index = ((int) (Time.time / timePerTexture)) % textures.Length;

		gameObject.GetComponent<SpriteRenderer> ().sprite = textures [index];
	}
}
