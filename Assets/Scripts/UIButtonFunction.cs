using UnityEngine;
using System.Collections;

public class UIButtonFunction : MonoBehaviour {
	public void OpenURL(string URL){
		Application.OpenURL (URL);
	}
}
