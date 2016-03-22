using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public Ball ball;

	private Vector3 offset;

	void Start () {
		offset = transform.position - ball.transform.position; 
	}
	
	void Update () {
		//in front of head pin
		if (ball.transform.position.z <= 1829f || ball.transform.position.y <= -5f) {
			transform.position = offset + ball.transform.position;
		}
	}
}
