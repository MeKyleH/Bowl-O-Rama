using UnityEngine;
using System.Collections;

public class ActionMaster {

	public enum Action {Tidy, Reset, EndTurn, EndGame};

	private int[] bowls = new int[21];
	private int frame = 1;

	public Action Bowl(int pins) {
		if (pins < 0 || pins > 10) {
			throw new UnityException ("Pins must be between 0 and 10.");
		}
		bowls [frame - 1] = pins;
		if (frame == 21) {
			return Action.EndGame;
		}

		//end of game
		if (frame >= 19 && Bowl21Awarded ()) {
			frame++;
			return Action.Reset;
		} else if (frame == 20 && !Bowl21Awarded()) {
			return Action.EndGame;
		}

		if (pins == 10) {
			frame += 2;
			return Action.EndTurn;
		}

		// end of frame
		if (frame % 2 == 0) {
			frame++;
			return Action.EndTurn;
		} else //mid frame or last frame
		{
			frame++;
			return Action.Tidy;
		}

		//if no known action is passed
		throw new UnityException ("Not sure what action to return.");
	}

	//checks frame 19 and 20 - array starts at 0
	private bool Bowl21Awarded() {
		return (bowls [18] + bowls [19] >= 10);
	}
}
