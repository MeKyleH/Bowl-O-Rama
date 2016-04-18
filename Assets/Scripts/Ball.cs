using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector3 launchVelocity;
	public bool inPlay = false;

	private Rigidbody rigidBody;
	private AudioSource audioSource;
	private Vector3 ballStartPos;
	private Quaternion ballStartRot;

	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		rigidBody.useGravity = false;

		ballStartPos = transform.position;
		ballStartRot = transform.rotation;
	}

	void Update() {
		if (inPlay && (rigidBody.position.y <= -10f || rigidBody.velocity.x == 0)) {
			Reset ();
		}
	}
	public void Launch (Vector3 velocity)
	{
		inPlay = true;

		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;
	
		audioSource = GetComponent<AudioSource>();
		audioSource.Play ();
	}

	public void Reset() {
		inPlay = false;

		rigidBody.position = ballStartPos;
		rigidBody.rotation = ballStartRot;
		rigidBody.useGravity = false;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
	}
}
