using UnityEngine;
using System.Collections;

public class LineController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Target.y = transform.position.y;
		Target.z = transform.position.z;
		Target.x = RightEdge;
	}
	public float RightEdge;
	public float LeftEdge;
	Vector3 Target;
	// Update is called once per frame
	void Update () {
		if (transform.position == Target) {
			if (Target.x == RightEdge) {
				Target.x = LeftEdge;
			} else if (Target.x == LeftEdge) {
				Target.x = RightEdge;
			}
		}
		transform.position = Vector3.MoveTowards (transform.position, Target, 2);

	}
}
