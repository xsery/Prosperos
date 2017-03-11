using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour {

	SpriteRenderer alpha;
	public Color flame;
	public float intense;

	// Use this for initialization
	void Start () {
		alpha = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		flame.a = (intense + Mathf.PingPong ((Time.time/2), Random.Range(0.01f, 0.05f)));
		alpha.color = flame;
	}

}
