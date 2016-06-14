using UnityEngine;
using System.Collections;

public class LineAnimationController : MonoBehaviour {
	Animator Anim;
	// Use this for initialization
	void Start () {
		Anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Screen.orientation == ScreenOrientation.Landscape) {
			GetComponent<RectTransform> ().rotation = Quaternion.Euler (0, 0, 90);
			Anim.SetBool ("Landscape", true);
			Anim.SetBool ("Portrait", false);
		}
		if (Screen.orientation == ScreenOrientation.Portrait) {
			GetComponent<RectTransform> ().rotation = Quaternion.Euler (0, 0, 0);
			Anim.SetBool ("Landscape", false);
			Anim.SetBool ("Portrait", true);
		}
	}
}
