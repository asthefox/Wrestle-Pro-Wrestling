using UnityEngine;
using System.Collections;

public class Wrestler : MonoBehaviour {
	
	public Conflict currentConflict;
	public Wrestler opponent;
	public Vector3 directionToOpponent;
	public float walkSpeed = 5;
	public float actionVelocity;
	
	
	void Start () {
		walkSpeed = .05f; //setting this again for now to compensate for prefabs not updating. Later remove this for custom inspector values
		actionVelocity = 0;
	}
	
	void Update () {
		if (currentConflict != null) {
			directionToOpponent = Vector3.Normalize ( opponent.transform.position - this.transform.position );
			
			switch (currentConflict._state) {
			case Conflict.State.Approach:
				transform.Translate ( directionToOpponent * (walkSpeed * (1 + actionVelocity)) , Space.World);
				break;
			case Conflict.State.Resolution:
				
				break;
			case Conflict.State.Reset:
				
				break;
			}
		}
	}
}
