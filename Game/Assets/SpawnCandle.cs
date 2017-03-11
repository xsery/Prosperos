using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCandle : MonoBehaviour {

	Animator player;
	public GameObject candle;
	bool instance = false;

	// Use this for initialization
	void Awake () {
		player = GameObject.Find ("Player").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetBool ("hasCandle") == false) {
			if (!instance) {
				Instantiate (candle, transform.position, Quaternion.identity);
				instance = true;
			}
		}
	}
}
