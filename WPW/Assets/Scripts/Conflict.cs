using UnityEngine;
using System.Collections;

public class Conflict : MonoBehaviour {
	
	public Wrestler wrestler1;
	public Wrestler wrestler2;
	
	public ActionMove resolvingMove;
	
	public bool approachingDone;
	public float approachingStopDistance;
	
	public enum State {
		Approach = 0,
		Resolution = 1,
		Reset = 2
	}
	public State state = State.Approach;
	
	void Start () {
		approachingDone = false;
		approachingStopDistance = 2;
	}
	
	void Update () {
	
		switch(state) {
		case State.Approach:
			if(!approachingDone && wrestler1.distanceToOpponent < approachingStopDistance) {
				Debug.Log("Stopping approach");
				approachingDone = true;
			}
			break;
		case State.Resolution:
			resolvingMove.UpdateHitting();
			break;
		case State.Reset:
			resolvingMove = null;
			state = State.Approach;
			approachingDone = false;
			break;
		}
	}
	
	public void SetResolution(ActionMove _resolvingMove){
		state = State.Resolution;
		resolvingMove = _resolvingMove;
	}
}
