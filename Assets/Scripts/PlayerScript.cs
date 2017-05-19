using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
	public GameObject player;
	public float speed = 5.0f;
	public float jumpUp = 10.0f;
	Rigidbody2D rb2d;
	bool jump = false;
	public LayerMask groundLayer;

	public Text time;
	public Text item;
	private float t = 0.0f;
	private int i = 0;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		time.text = "Time: 0";
		item.text = "Item: 0";
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		time.text = "Time: " + t.ToString ("f2");

		jump = Physics2D.Linecast (transform.position, transform.position - transform.up * 0.8f, groundLayer);

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
			iTween.RotateTo (player, iTween.Hash ("y", 180, "time", 1.0f));
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
			iTween.RotateTo (player, iTween.Hash ("y", 0, "time", 1.0f));
		}
		if (Input.GetKey (KeyCode.UpArrow) && jump) {
			rb2d.AddForce (Vector2.up * jumpUp);
			jump = true;
		}
	}

	void CountItem () {
		i++;
		item.text = "Item: " + i.ToString ();
	}
}
