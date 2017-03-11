using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour {

	public GameObject player;
	public TextBox textBox;

	void Awake(){
		textBox = GameObject.Find ("TextBoxManager").GetComponent<TextBox> ();
	}

	void Start () {
		//PlayerPrefs.SetInt("spawned", 0);
		if (PlayerPrefs.GetInt ("spawned") == 0) {
			GameObject newPlayer = Instantiate (player, transform.position, Quaternion.identity);
			newPlayer.name = "Player";
			GameObject.Find ("PlayerCandle").SetActive (true);
			textBox.ShowText ();
			PlayerPrefs.SetInt("spawned", 1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){
			PlayerPrefs.SetInt("spawned", 0);
		}
	}
}
