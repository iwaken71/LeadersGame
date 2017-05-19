using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour {
	public Rigidbody2D rgb2D;

	// Use this for initialization
	void Start () {
		rgb2D.velocity = transform.right * -2.0f;

	}
	
	// Update is called once per frame
	void Update () {
		rgb2D.velocity = transform.right * -2.0f;
	}

	void OnTriggerEnter2D (Collider2D hit) {
		if (hit.CompareTag ("Player")) {
			hit.SendMessage ("Damage");
			Destroy (gameObject);
		} else if (hit.CompareTag ("Arrow")) {
			Destroy (hit.gameObject);
			Destroy (gameObject);
		}
	}
}
