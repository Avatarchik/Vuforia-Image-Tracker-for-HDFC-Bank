using UnityEngine;
using System.Collections;

public class Marker : MonoBehaviour {

	void Start(){
		if (gameObject.layer == 0) {
			if (GetComponentInParent<Canvas> ().enabled) {
				GetComponent<Renderer> ().enabled = true;
			} else {
				GetComponent<Renderer> ().enabled = false;
			}
		}
	}
	void Update(){
		if (gameObject.layer == 0) {
			if (GetComponentInParent<Canvas> ().enabled) {
				GetComponent<Renderer> ().enabled = true;
			} else {
				GetComponent<Renderer> ().enabled = false;
			}
		}
	}
}
