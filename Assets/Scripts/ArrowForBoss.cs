using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowForBoss : MonoBehaviour {
	public Rigidbody2D rgb2D;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		rgb2D.velocity = transform.right * -2.0f;
	}

	void OnTriggerEnter2D (Collider2D hit) {
		if (hit.CompareTag ("Enemy")) {
			hit.SendMessage ("Damage");
			Destroy (gameObject);
		}
	}
}
