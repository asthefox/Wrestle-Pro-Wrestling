using UnityEngine;
using System.Collections;

public class Conflict : MonoBehaviour {
	
	public Wrestler wrestler1;
	public Wrestler wrestler2;
	
	public enum State {
		Approach = 0,
		Resolution = 1,
		Reset = 2
	}
	public State _state = State.Approach;
	
	void Start () {
	
	}
	
	void Update () {
	
	}
}
