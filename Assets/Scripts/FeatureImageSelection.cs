using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FeatureImageSelection : MonoBehaviour {
	public Image[] FeatureImages;
	ScrollRect thisScroll;
	int CurIndex;

	void Start () {
		CurIndex = 0;
		thisScroll = GetComponentInChildren<ScrollRect> ();
		FeatureImages [CurIndex].enabled = true;
		for (int pass = 1; pass < FeatureImages.Length; pass++) {
			FeatureImages [pass].enabled = false;
		}
		thisScroll.content = FeatureImages [CurIndex].rectTransform;	
	}
	
	/* 
	float timer = 1;
	bool CanCall = false;
	void Update () {
		
		if (timer >= 0.1f ) {
			if (Input.touches.Length > 0) {
				if (Input.GetTouch (0).deltaPosition.x > 3 && CanCall && Mathf.Abs(Input.GetTouch (0).deltaPosition.y) < 2) {
					thisScroll.vertical = false;

					FeatureImages [CurIndex].enabled = false;
					if (CurIndex == 0) {
						CurIndex = FeatureImages.Length - 1;
					} else {
						CurIndex--;
					}
					FeatureImages [CurIndex].enabled = true;
					thisScroll.content = FeatureImages [CurIndex].rectTransform;
					CanCall = false;
					timer = 0;

				} else if (Input.GetTouch (0).deltaPosition.x < -3 && CanCall && Mathf.Abs(Input.GetTouch (0).deltaPosition.y) < 2) {
					thisScroll.vertical = false;

					FeatureImages [CurIndex].enabled = false;
					if (CurIndex == FeatureImages.Length - 1) {
						CurIndex = 0;
					} else {
						CurIndex++;
					}
					FeatureImages [CurIndex].enabled = true;
					thisScroll.content = FeatureImages [CurIndex].rectTransform;
					CanCall = false;
					timer = 0;
				}
			}
		} else {
			timer += Time.deltaTime;
		}
		if (Input.touches.Length > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && !CanCall) {
			thisScroll.vertical = true;
			CanCall = true;
		}
	}*/


	public void ChangeIdex(int value){
		switch (value) {
		case -1:
			
			FeatureImages [CurIndex].enabled = false;
			if (CurIndex == 0) {
				CurIndex = FeatureImages.Length - 1;
			} else {
				CurIndex--;
			}
			FeatureImages [CurIndex].enabled = true;
			thisScroll.content = FeatureImages [CurIndex].rectTransform;

			break;
		case 1:

			FeatureImages [CurIndex].enabled = false;
			if (CurIndex == FeatureImages.Length - 1) {
				CurIndex = 0;
			} else {
				CurIndex++;
			}
			FeatureImages [CurIndex].enabled = true;
			thisScroll.content = FeatureImages [CurIndex].rectTransform;

			break;
		}
	}
}
