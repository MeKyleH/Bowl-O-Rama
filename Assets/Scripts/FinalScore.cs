using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

	private Text text;

	void Start () {
		text = GetComponent<Text> ();
		text.text = ScoreDisplay.finalScore.ToString();
	}
}
