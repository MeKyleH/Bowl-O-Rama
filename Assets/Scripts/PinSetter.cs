using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {
	public int lastStandingCount = -1;
	public Text standingDisplay;
	public GameObject pinSet;

	private bool ballEnteredBox = false;
	private float lastChangeTime;
	private Ball ball;

	void Start() {
		ball = GameObject.FindObjectOfType<Ball> ();
	}

	void Update () {
		standingDisplay.text = CountStanding ().ToString ();

		if (ballEnteredBox) {
			UpdateStandingCountAndSettle ();
		}
	}

	public void RaisePins() {
		Debug.Log("Raising pins");
		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.RaiseIfStanding ();
		}	
	}

	public void LowerPins() {
		Debug.Log ("Lowering pins");
		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()) {
				pin.Lower ();
		}	
	}

	public void RenewPins() {
		Debug.Log ("Renewing pins");
		GameObject newPins = Instantiate (pinSet);
		newPins.transform.position += new Vector3(0, 20, 0);
	}

	void UpdateStandingCountAndSettle() {
		//update the lastStandingCount
		int currentStanding = CountStanding();

		if(currentStanding != lastStandingCount) {
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}

		//wait 3 seconds for pins to settled
		float settleTime = 3f;
		if ((Time.time - lastChangeTime) > settleTime) {
			PinsHaveSettled ();
		}
	}

	void PinsHaveSettled() {
		ball.Reset ();
		lastStandingCount = -1;
		ballEnteredBox = false;
		standingDisplay.color = Color.green;
	}

	int CountStanding() {
		int standing = 0;
		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if(pin.IsStanding()) {
				standing++;
			}
		}
		return standing;
	}

	void OnTriggerEnter (Collider collider) {
		GameObject thingHit = collider.gameObject;

		//ball enteres play box
		if (thingHit.GetComponent<Ball> ()) {
			ballEnteredBox = true;
			standingDisplay.color = Color.red;
		}
	}
}
