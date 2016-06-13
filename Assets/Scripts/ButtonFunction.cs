using UnityEngine;
using System.Collections;

public class ButtonFunction : MonoBehaviour {
	public string URLToCall;
	public bool Controller;
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
	public void Funtion(){
		Application.OpenURL (URLToCall);
	}


}
