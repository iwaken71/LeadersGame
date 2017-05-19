using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
	public Text time;
	public Text item;
	private float t = 0.0f;
	private int i = 0;
	GameObject obj;

	// Use this for initialization
	void Start () {
		time.text = "Time: 0";
		item.text = "Item: 0";
	}
	
	// Update is called once per frame
	void Update () {

	}
	

}
