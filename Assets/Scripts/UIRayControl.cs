using UnityEngine;
using System.Collections;

public class UIRayControl : MonoBehaviour {

	Camera Cam;
	public LayerMask UILayer;
	void Start () {
		Cam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			RaycastHit Hit;
			Ray Check = Cam.ScreenPointToRay (Input.GetTouch (0).position);
			if (Physics.Raycast (Check, out Hit, 10000, UILayer)) {
				Hit.collider.gameObject.GetComponent<ButtonFunction> ().Funtion ();
			}
		}


	}
}
