using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossOne : MonoBehaviour {
	public Slider hp;
	public Transform bone;
	float timer = 0.0f;
	float interval = 0.5f;
	private Vector3 offset;
	private Vector3 vec;

	// Use this for initialization
	void Start () {
		offset = new Vector3 (-1, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
		timer += Time.deltaTime;
		if (timer >= interval) {
			Quaternion q = new Quaternion();
			q= Quaternion.identity;
			vec = new Vector3 (transform.position.x, Random.Range (0.2f, 2.0f), transform.position.z) + offset;
			Instantiate(bone, vec, q);
			timer = 0;
		}
	}

	void Damage () {
		if (hp.value > 1) {
			hp.value--;
		} else {
			Destroy (gameObject);
			SceneManager.LoadScene ("START");
		}
	}
}
