using UnityEngine;
using System.Collections;

public class DisplayViedosHyundai : MonoBehaviour {

	public Canvas MenuCanvas;
	public Canvas BackButtonCanvas;
	public GameObject SecondCamera;
	public GameObject[] Videos;
	void Start () {
	}
	
	public void LoadVideos(int pass){
		MenuCanvas.enabled = false;
		YoutubeVideo.Instance.CanQuit = false;
		YoutubeVideo.Instance.MenuOpen = true;

		Videos [pass].GetComponent<SetUpSecondScreen> ().Normalized = true;
		Videos [pass].GetComponent<Renderer> ().enabled = true;
		Videos [pass].GetComponent<Collider> ().enabled = true;
		Renderer[] rendererComponentsRelated = Videos[pass].GetComponentsInChildren<Renderer>();
		Collider[] colliderComponentsRelated = Videos[pass].GetComponentsInChildren<Collider>();

		foreach (Renderer component in rendererComponentsRelated)
		{
			component.enabled = true;
		}


		foreach (Collider component in colliderComponentsRelated)
		{
			component.enabled = true;
		}
	
		SecondCamera.GetComponent<VideoPlaybackController> ().enabled = true;
	}

	public void CloseVideos(){
		for (int pass = 0; pass < Videos.Length; pass++) {
			Videos [pass].GetComponent<VideoPlaybackBehaviour> ().VideoPlayer.SeekTo (0);

			Renderer[] rendererComponentsRelated = Videos[pass].GetComponentsInChildren<Renderer>();
			Collider[] colliderComponentsRelated = Videos[pass].GetComponentsInChildren<Collider>();


			// Disable rendering:
			foreach (Renderer component in rendererComponentsRelated)
			{
				component.enabled = false;
			}

			// Disable colliders:
			foreach (Collider component in colliderComponentsRelated)
			{
				component.enabled = false;
			}
		}

	}

}
