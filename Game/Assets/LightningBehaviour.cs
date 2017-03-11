using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBehaviour : MonoBehaviour {

	SpriteRenderer sprite;
	public Color lightningAlpha;
	bool isRainning = true;
	public bool isLightning = false;

	float nextLightning;
	public float duration;


	void Start(){
		sprite = GetComponent<SpriteRenderer> ();
		StartCoroutine ("LightninFlash");
	}

	void Update(){
		if (isLightning) {
			LightningFlash ();
		}
	}

	void LightningFlash(){
			lightningAlpha.a = (Mathf.PingPong ((Time.time), Random.Range (0.25f, 0.5f)));
			sprite.color = lightningAlpha;
	}

	IEnumerator LightninFlash(){
		while (isRainning) {
			isLightning = true;
			yield return new WaitForSeconds (duration);
			isLightning = false;
			lightningAlpha.a = 0;
			sprite.color = lightningAlpha;
			nextLightning = Random.Range (4, 10);
			yield return new WaitForSeconds (nextLightning);
		}
	}


}
