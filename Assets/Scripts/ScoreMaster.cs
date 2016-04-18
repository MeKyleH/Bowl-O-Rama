using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ScoreMaster {

	//Returns a list of cumulative scores, like a normal score card.
	public static List<int> ScoreCumulative (List<int> rolls) {
		List<int> cumulativeScores = new List<int> ();
		int runningTotal = 0;

		foreach (int frameScore in ScoreFrames (rolls)) {
			runningTotal += frameScore;
			cumulativeScores.Add (runningTotal);
		}
		return cumulativeScores;
	}

	//Return a list of individual frame scores
	public static List<int> ScoreFrames (List<int> rolls) {
		List<int> frames = new List<int> ();

		for (int i = 1; i < rolls.Count; i += 2) {
			if (frames.Count == 10) {						//Prevents 11th frame score
				break;
			}

			if(rolls[i-1] + rolls[i] < 10) {				//normal open frame (sum of 2 bowls is less than 10)
				frames.Add (rolls [i-1] + rolls[i]);
			}

			if(rolls.Count - i <= 1) { 						//need at least 1 look-ahead
				break;
			}	

			if (rolls [i - 1] == 10) {						//calculate STRIKE bonus
				i--;										//strike frame only has one bowl
				frames.Add (10 + rolls [i + 1] + rolls [i + 2]);
			} else if(rolls[i-1] + rolls[i] == 10) {		//calculate SPARE bonus
				frames.Add (10 + rolls[i+1]);
			}
		}
		for (int i = 0; i < frames.Count; i++) {
		}
		return frames;
	}
}
