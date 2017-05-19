using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerForBoss : MonoBehaviour {
	public GameObject player;
	public Transform arrow;
	public Slider hp;
	private Vector3 offset;


	public float speed = 5.0f;
	public float jumpUp = 10.0f;
	Rigidbody2D rb2d;
	bool jump = false;
	public LayerMask groundLayer;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		offset = new Vector3 (0.5f, 0, 0);
	}
		
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			//配置する回転角を設定
			Quaternion q = new Quaternion();
			q= Quaternion.identity;
			q.y = 180;
			Instantiate(arrow, player.transform.position + offset, q);
		}

		jump = Physics2D.Linecast (transform.position, transform.position - transform.up * 0.8f, groundLayer);

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
//			iTween.RotateTo (player, iTween.Hash ("y", 180, "time", 1.0f));
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
//			iTween.RotateTo (player, iTween.Hash ("y", 0, "time", 1.0f));
		}
		if (Input.GetKey (KeyCode.UpArrow) && jump) {
			rb2d.AddForce (Vector2.up * jumpUp);
			jump = true;
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
