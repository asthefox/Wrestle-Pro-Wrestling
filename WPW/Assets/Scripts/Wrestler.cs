using UnityEngine;
using System.Collections;

public class Wrestler : MonoBehaviour {
	
	public enum State {
		Idle = 0,
		Strike = 1,
		Grapple = 2,
		Counter = 3
	}
	
	public GameObject face;
	
	public Material strikeMat;
	public Material counterMat;
	public Material grappleMat;
	public Material defaultMat;
	
	public State state = State.Idle;
	
	public Grapple grappleMove;
	public Counter counterMove;
	public Strike strikeMove;
	
	public WrestlerInput input;
	public Conflict currentConflict;
	public ActionMove currentAction;
	public Wrestler opponent;
	public Vector3 directionToOpponent;
	public float distanceToOpponent;
	public float walkSpeed = 5;
	public float actionVelocity;
	public float stopDistance = 2;
	
	
	void Start () {
		walkSpeed = .05f; //setting this again for now to compensate for prefabs not updating. Later remove this for custom inspector values
		actionVelocity = 0;
		face = transform.FindChild("Sphere").gameObject;
	}
	
	void Update () {
		if (currentConflict != null) {
			directionToOpponent = Vector3.Normalize ( opponent.transform.position - this.transform.position );
			distanceToOpponent = Vector3.Distance(opponent.transform.position, this.transform.position);
			switch (currentConflict.state) {
			case Conflict.State.Approach:
				if(state == State.Idle) {
					input.HandleApproachInput();
				}
				else {
					currentAction.UpdateMove();
				}
				if(distanceToOpponent > stopDistance)
				{
					transform.Translate ( directionToOpponent * (walkSpeed * (1 + actionVelocity)) , Space.World);
				}
				else
				{
					transform.Translate ( directionToOpponent * (walkSpeed * actionVelocity) , Space.World);
				}
				break;
			case Conflict.State.Resolution:
				
				break;
			case Conflict.State.Reset:
				
				break;
			}
		}
	}
	
	public void StartGrapple(){
		state = State.Grapple;
		grappleMove.StartMove();
		face.renderer.material = grappleMat;
	}
	
	public void StartStrike(){
		state = State.Strike;
		strikeMove.StartMove();
		face.renderer.material = strikeMat;
	}
	
	public void StartCounter(){
		state = State.Counter;
		counterMove.StartMove();
		face.renderer.material = counterMat;
	}
}
