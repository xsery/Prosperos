using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {

	public string keyId;

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<PlayerMovement> ().keys.Add (keyId);
			Destroy (this.gameObject);
		}
	}
}
