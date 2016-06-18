using UnityEngine;
using System.Collections;

public class MenuCanvasManager : MonoBehaviour {

	Canvas thisCanvas;
	// Use this for initialization
	void Start () {
		thisCanvas = GetComponent<Canvas> ();
	}

	public void SwitchCanvas(bool value){
		thisCanvas.enabled = value;
		if (value) {
			YoutubeVideo.Instance.MenuOpen = true;
		}
	}
}
