using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public Object scene;

	void Start () {
		StartCoroutine("ChangeToScene");
	}

	IEnumerator ChangeToScene(){
		yield return new WaitForSeconds (7.5f);
		SceneManager.LoadScene (scene.name);
	}
}
