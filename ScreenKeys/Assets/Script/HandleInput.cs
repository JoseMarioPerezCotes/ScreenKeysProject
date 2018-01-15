using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleInput : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode))) {
			if (Input.GetKeyUp (key)) {
				Debug.Log ("Key Pressed:" + key.ToString ());
			}
		}
	}
}
