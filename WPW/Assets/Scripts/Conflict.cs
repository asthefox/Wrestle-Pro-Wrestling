using UnityEngine;
using System.Collections;

public class Conflict : MonoBehaviour {
	
	public Wrestler wrestler1;
	public Wrestler wrestler2;
	
	public ActionMove resolvingMove;
	
	public enum State {
		Approach = 0,
		Resolution = 1,
		Reset = 2
	}
	public State state = State.Approach;
	
	void Start () {
			
	}
	
	void Update () {
	
		switch(state) {
		case State.Resolution:
			resolvingMove.UpdateHitting();
			break;
		case State.Reset:
			resolvingMove = null;
			state = State.Approach;
			break;
		}
	}
	
	public void SetResolution(ActionMove _resolvingMove){
		state = State.Resolution;
		resolvingMove = _resolvingMove;
	}
}
