using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryOneScript : MonoBehaviour {
	[SerializeField] string[] scenarios;
	[SerializeField] Text uiText;
	[SerializeField] [Range(0.001f, 0.6f)]
	float intervalForCharacterDisplay = 0.1f;

	private string currentText = string.Empty;
	private float timeUntilDisplay = 0;
	private float timeElapsed = 1;
	private int currentLine = 0;
	private int lastUpdateCharacter = -1;

	public bool IsCompleteDisplayText {
		get { return Time.time > timeElapsed + timeUntilDisplay; }
	}



	void Start () {
		SetNextLine ();
	}
		
	void Update () {
		if (IsCompleteDisplayText) {
			if (currentLine < scenarios.Length && Input.GetKeyDown (KeyCode.Space)) {
				SetNextLine ();
			}
		} else {
			if (Input.GetKeyDown (KeyCode.Space)) {
				timeUntilDisplay = 0;
			}
		}
		int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);
		if( displayCharacterCount != lastUpdateCharacter ){
			uiText.text = currentText.Substring(0, displayCharacterCount);
			lastUpdateCharacter = displayCharacterCount;
		}
		if (currentLine == scenarios.Length) {
			SceneManager.LoadScene ("Stage01");
		}

	}

	void SetNextLine () {
		currentText = scenarios[currentLine];
		timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
		timeElapsed = Time.time;
		currentLine ++;
		lastUpdateCharacter = -1;
	}


}
