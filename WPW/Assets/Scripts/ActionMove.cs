using UnityEngine;
using System.Collections;

public class ActionMove : MonoBehaviour {
	
	public enum State 
	{
		Tell = 0,
		Active = 1,
		Cooldown = 2
	}
	public State _state = State.Tell;

	public void Start () {
		Debug.Log ("ActionMove Starting");
	}
	
	void Update () {
	
	}
}
