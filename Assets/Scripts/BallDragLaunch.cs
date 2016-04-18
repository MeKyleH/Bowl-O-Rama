using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Ball))]
public class BallDragLaunch : MonoBehaviour {

	private Vector3 dragStart, dragEnd;
	private float startTime, endTime;
	private Ball ball;

	void Start () {
		ball = GetComponent<Ball> ();
	}

	public void MoveStart(int amount) {
		if (!ball.inPlay) {
			float xPos = Mathf.Clamp(ball.transform.position.x + amount, - 50f, 50f);
			float yPos = ball.transform.position.y;
			float zPos = ball.transform.position.z;
			ball.transform.position = new Vector3 (xPos, yPos, zPos);
		}
	}

	public void DragStart() {
		if (ball.inPlay) {
			return;
		}
		//capture time and position of drag start
		dragStart = Input.mousePosition;
		startTime = Time.time;
	}

	public void DragEnd() {
		if (ball.inPlay) {
			return;
		}
		// Launch the ball
		dragEnd = Input.mousePosition;
		endTime = Time.time;

		float dragDuration = endTime - startTime;

		float launchSpeedX = Mathf.Clamp((dragEnd.x - dragStart.x) / dragDuration, -100f, 100f);
		float launchSpeedZ = Mathf.Clamp ((dragEnd.y - dragStart.y) / dragDuration, -500f, 500f);

		Vector3 launchVelocity = new Vector3 (launchSpeedX, 0, launchSpeedZ);

		ball.Launch (launchVelocity);
	}
}
