using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour {

	public TextAsset[] textFile;
	public int currentText;
	public List<string> textLines = new List<string>();

	public GameObject textBox;
	public Text theText;

	public bool showTextBox;
	public int currentLine;
	public int endLine;

	public PlayerMovement player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerMovement> ();
		ChangeText (0);

	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
			player = GameObject.Find ("Player").GetComponent<PlayerMovement> ();
		}

		if (showTextBox) {
			textBox.SetActive (true);
			player.canMove = false;
			showTextBox = false;
			Debug.Log ("123");
		}

		theText.text = textLines [currentLine];
		if (Input.GetKeyDown(KeyCode.Space)){
			currentLine++;
		}

		if (currentLine > endLine) {
			currentLine = 0;
			textBox.SetActive (false);
			player.canMove = true;
		}
	}

	public void ShowText(){
		showTextBox = true;
	}

	public void ChangeText(int text){
		if (textFile != null) {
			string[] tempText = (textFile [text].text.Split ('\n'));
			textLines.Clear ();
			foreach (string s in tempText){
				textLines.Add (s);
			}
			endLine = textLines.Count - 1;
		}

		if (endLine == 0) {
			endLine = textLines.Count - 1;
		}
	}

	public void ChangeLine(int line){
		currentLine = line;
	}
}
