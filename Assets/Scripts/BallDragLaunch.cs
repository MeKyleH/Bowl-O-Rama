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
			ball.transform.Translate (new Vector3 (amount, 0, 0));
		}
	}

	public void DragStart() {
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

		float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
		float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

		Vector3 launchVelocity = new Vector3 (launchSpeedX, 0, launchSpeedZ);

		ball.Launch (launchVelocity);
	}
}
