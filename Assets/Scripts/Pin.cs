﻿using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	public float standingThreshold = 3f;
	public float distToRaise = 55f;

	private Rigidbody rigidBody;

	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}

	public bool IsStanding() {
		Vector3 rotationInEuler = transform.rotation.eulerAngles;

		float tiltInX = Mathf.Abs(270 - rotationInEuler.x);
		float tiltInZ = Mathf.Abs(rotationInEuler.z);

		if(tiltInX < standingThreshold && tiltInZ < standingThreshold){
			return true;
		}
		return false;
	}

	public void RaiseIfStanding() {
		if(IsStanding()) {
			rigidBody.useGravity = false;
			transform.Translate(new Vector3(0, distToRaise, 0), Space.World);
			transform.rotation = Quaternion.Euler (270f, 0f, 0f);
		}
	}

	public void Lower() {
		transform.Translate(new Vector3(0, -distToRaise, 0), Space.World);
		rigidBody.useGravity = true;
	}
}
