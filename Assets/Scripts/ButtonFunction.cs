using UnityEngine;
using System.Collections;

public class ButtonFunction : MonoBehaviour {
	public string URLToCall;
	public bool Controller;
	public Canvas MenuCanvas;
	public Canvas VideoCanvas;
	Marker[] MarkedArray;

	void Start(){
		MarkedArray = (Marker[])FindObjectsOfType <Marker> ();
	}
	bool canQuit;
	void Update(){
		if (Controller) {

			foreach (Marker m in MarkedArray) {
				if (m.GetComponent<Renderer> ().enabled) {
					canQuit = false;
					break;
				} else {
					canQuit = true;
				}
			}


			if (!canQuit) {
				YoutubeVideo.Instance.CanQuit = false;
			} else {
				YoutubeVideo.Instance.CanQuit = true;
			}
		}
	}
	public bool OpenURL;
	public bool BackButton;
	public int MenuLevel;
	public void Funtion(){
		if (OpenURL) {
			Application.OpenURL (URLToCall);
		} else if (BackButton) {
			FindObjectOfType<TrackableEventHandler> ().CloseVideos ();
			if (MenuLevel != 1) {				
				MenuCanvas.GetComponent<MenuCanvasManager> ().SwitchCanvas (true);
			} else {
				VideoCanvas.GetComponent<MenuCanvasManager> ().SwitchCanvas (true);
			}
		}
	}


}
