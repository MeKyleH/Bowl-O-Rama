using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinCounter : MonoBehaviour {
	public Text standingDisplay;

	private GameManager gameManager;
	private int lastStandingCount = -1;
	private bool ballOutOfPlay = false;
	private float lastChangeTime;
	private int lastSettledCount = 10;

	void Start() {
		gameManager = GameObject.FindObjectOfType<GameManager> ();
	}
	
	void Update () {
		standingDisplay.text = CountStanding ().ToString ();

		if (ballOutOfPlay) {
			standingDisplay.color = Color.red;
			UpdateStandingCountAndSettle ();
		}
	}

	public void Reset() {
		lastSettledCount = 10;
	}

	void OnTriggerExit (Collider collider) {
		if (collider.gameObject.name == "Ball") {
			ballOutOfPlay = true;
		}
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
		int standing = CountStanding ();
		int pinFall = lastSettledCount - standing;
		lastSettledCount = standing;

		gameManager.Bowl (pinFall);

		lastStandingCount = -1;
		ballOutOfPlay = false;
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
}
