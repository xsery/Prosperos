using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentBehaviour : MonoBehaviour {

	public InstrumentManager instManager;
	//public AudioSource sound;
	public int instrumentId;
	bool canPlay = false;

	void Start(){
		instManager = GameObject.Find ("InstrumentManager").GetComponent<InstrumentManager> ();
	}

	void Update(){
		if ((Input.GetKeyDown(KeyCode.Space)) && (canPlay)){
			//sound.Play();
			instManager.played.Add (instrumentId);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			canPlay = true;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			canPlay = false;
		}
	}
}
