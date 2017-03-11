using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorBehaviour : MonoBehaviour {

	public bool hasLock = false;
	public string doorId;

	public Transform player;

	public bool isWall;
	public bool isStair;
	bool onStair = false;
	public bool isLocked;
	public bool needKey;
	public Object toRoom;

	private TextBox textShow;

	void Start(){
		if (isStair) {
			GetComponent<BoxCollider2D> ().isTrigger = true;
		}
		textShow = GameObject.Find ("TextBoxManager").GetComponent<TextBox> ();
	}

	void Update(){
		if (onStair) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				player = GameObject.Find ("Player").transform;
				if (isLocked) {
					for (int i = 0; i < player.GetComponent<PlayerMovement> ().keys.Count; i++) {
						if (player.GetComponent<PlayerMovement> ().keys [i] == doorId) {
							isLocked = false;
						} else {
							//Mensagem de que não é hora de subir as escadas;
						}
					}
				}
				if (!isLocked) {
					if (this.gameObject.name == "R_stair") {
						player.GetComponent<PlayerMovement> ().spawnOnLeft = true;
						player.GetComponent<PlayerMovement> ().spawned = false;
					} else if (this.gameObject.name == "L_stair") {
						player.GetComponent<PlayerMovement> ().spawnOnLeft = false;
						player.GetComponent<PlayerMovement> ().spawned = false;
					}
					SceneManager.LoadScene (toRoom.name);
				}
			}
		}

		if (hasLock) {
			if (PlayerPrefs.GetInt (doorId) == 0) {
				isLocked = true;
			} else {
				isLocked = false;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (isLocked) {
			textShow.ShowText ();
			textShow.ChangeText (1);
			if ((col.gameObject.tag == "Player") && (col.gameObject.GetComponent<PlayerMovement>().keys.Count != 0)) {
				for (int i = 0; i < col.gameObject.GetComponent<PlayerMovement> ().keys.Count; i++) {
					if (col.gameObject.GetComponent<PlayerMovement> ().keys[i] == doorId) {
						textShow.ShowText ();
						textShow.ChangeText (2);
						isLocked = false;
					}
				}
			}
			Debug.Log ("Is Locked!");
		}

		if ((!isLocked) && (!isStair) && (col.gameObject.GetComponent<PlayerMovement> ().spawned == true)) {
			if ((col.gameObject.tag == "Player") && (!isWall)) {
				if (this.gameObject.name == "R_door") {
					col.gameObject.GetComponent<PlayerMovement> ().spawnOnLeft = true;
					col.gameObject.GetComponent<PlayerMovement> ().spawned = false;
				} else if (this.gameObject.name == "L_door") {
					col.gameObject.GetComponent<PlayerMovement> ().spawnOnLeft = false;
					col.gameObject.GetComponent<PlayerMovement> ().spawned = false;
				}
				SceneManager.LoadScene (toRoom.name);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			onStair = true;
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			onStair = false;
		}
	}
}
