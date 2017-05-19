using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
	public GameObject player;
	private Vector3 camera;
	private Vector3 offset = new Vector3(0f,0.6f,3.5f);

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		camera = player.transform.position + offset;
		transform.position	= Vector3.Lerp(transform.position, camera, 2f*Time.deltaTime);
		camera.y = 0.96f;
	}
}
