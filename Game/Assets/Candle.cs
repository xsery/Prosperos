using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour {

	SpriteRenderer alpha;
	public Color flame;
	public float intense;
	public bool newCandle = false;

	Animator player;

	// Use this for initialization
	void Start () {
		alpha = GetComponent<SpriteRenderer> ();
		player = GameObject.Find ("Player").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if ((player.GetBool ("hasCandle") == true) || (newCandle)) {
			flame.a = (intense + Mathf.PingPong ((Time.time / 2), Random.Range (0.01f, 0.05f)));
			alpha.color = flame;
		}
	}

}
