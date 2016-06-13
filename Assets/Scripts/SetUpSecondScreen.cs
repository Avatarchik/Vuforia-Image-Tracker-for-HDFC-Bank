using UnityEngine;
using System.Collections;

public class SetUpSecondScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	public bool Normalized;
	// Update is called once per frame
	void Update () {
		if (!Normalized) {
			GetComponent<Renderer> ().enabled = false;
			GetComponent<Collider> ().enabled = false;

			Renderer[] rendererComponents = GetComponentsInChildren<Renderer> ();
			Collider[] colliderComponents = GetComponentsInChildren<Collider> ();

			// Enable rendering:
			foreach (Renderer component in rendererComponents) {
				component.enabled = false;
			}

			// Enable colliders:
			foreach (Collider component in colliderComponents) {
				component.enabled = false;
			}

		} else {
			this.enabled = false;
		}
	}
}
