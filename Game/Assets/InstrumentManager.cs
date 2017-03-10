using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentManager : MonoBehaviour {

	public List<int> order = new List<int> ();
	public List<int> played = new List<int> ();

	public string keyId;
	bool isSolved;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!isSolved) {
			if (played.Count != 0) {
				for (int i = 0; i < played.Count; i++) {
					if (played [i] == order [i]) {
						continue;
					} else {
						played.Clear ();
					}
				}
				if (played.Count == 4) {
					GameObject.Find ("Player").GetComponent<PlayerMovement> ().keys.Add (keyId);
					isSolved = true;
				}
			}
		}
	}
}
