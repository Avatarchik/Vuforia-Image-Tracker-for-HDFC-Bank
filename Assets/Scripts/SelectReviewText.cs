using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectReviewText : MonoBehaviour {
	public Text Review1;
	public Text Review2;

	Vector3 Review1Rect;
	Vector3 Review2Rect;
	public ScrollRect thisScroll;
	void Start () {
		Review1Rect = Review1.rectTransform.transform.position;
		Review2Rect = Review2.rectTransform.transform.position;
		thisScroll = GetComponent<ScrollRect> ();
		Review2.enabled = false;
		Review1.enabled = true;
	}
	
	public void ChoseReview(int choice){
		thisScroll.enabled = false;
		thisScroll.gameObject.SetActive (false);
		switch (choice) {
		case 1:
			Review1.enabled = true;

			thisScroll.content = Review1.rectTransform;

			Review2.enabled = false;
			Review1.rectTransform.position = Review1Rect;
			break;
		case 2:
			Review2.enabled = true;

			thisScroll.content = Review2.rectTransform;
			Review2.rectTransform.position = Review2Rect;
			Review1.enabled = false;
			break;
		}
		thisScroll.gameObject.SetActive (true);
		thisScroll.enabled = true;
	}
}
