using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {
	public GameObject pinSet;

	private PinCounter pinCounter;
	private LevelManager levelManager;
	private Animator animator;

	void Start() {
		animator = GetComponent<Animator> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		pinCounter = GameObject.FindObjectOfType<PinCounter> ();
	}

	public void RaisePins() {
		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.RaiseIfStanding ();
		}	
	}

	public void LowerPins() {
		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()) {
				pin.Lower ();
		}	
	}

	public void RenewPins() {
		GameObject newPins = Instantiate (pinSet);
		newPins.transform.position += new Vector3(0, 20, 0);
	}

	public void PerformAction(ActionMaster.Action action) {
		if (action == ActionMaster.Action.Tidy) {
			animator.SetTrigger ("tidyTrigger");
		} else if (action == ActionMaster.Action.Reset) {
			animator.SetTrigger ("resetTrigger");
			pinCounter.Reset ();
		} else if (action == ActionMaster.Action.EndTurn) {
			animator.SetTrigger ("resetTrigger");
			pinCounter.Reset ();
		} else if (action == ActionMaster.Action.EndGame) {
			levelManager.LoadLevel ("03 Game Over");
		}
	}
}
