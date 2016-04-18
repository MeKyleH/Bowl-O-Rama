using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public  List<int> rolls = new List<int>();

	private Ball ball;
	private PinSetter pinSetter;
	private ScoreDisplay scoreDisplay;

	void Start () {
		pinSetter = GameObject.FindObjectOfType<PinSetter> ();
		ball = GameObject.FindObjectOfType<Ball> ();
		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay> ();
	}

	public void Bowl (int pinFall) {

		rolls.Add (pinFall);
		List<int> rollHolder = new List<int> (rolls);
		ball.Reset ();

		pinSetter.PerformAction (ActionMaster.NextAction (rollHolder));

		scoreDisplay.FillRolls (rolls); 
		scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
	}
}
