using UnityEngine;
using System.Collections;

public class ActionMove : MonoBehaviour {
	
	public enum State {
		Tell = 0,
		Active = 1,
		Cooldown = 2
	}
	
	public Wrestler owner;
	
	public State _state = State.Tell;
	public float timer = 0;
	
	// All times in milliseconds
	public float tellTime = 200;
	public float activeTime = 200;
	public float cooldownTime = 200;
	
	public float tellVelocity = 0;
	public float activeVelocity = 0;
	public float cooldownVelocity = 0;	
	

	public void Start () {
		owner = GetComponent<Wrestler>();
		timer = 0;
		_state = State.Tell;
		//Debug.Log ("ActionMove Starting");
	}
	
	public void StartMove () {
		StartTell();
	}
	
	public void UpdateMove () {
		switch(_state){
		case(State.Tell):
			UpdateTell();
			break;
		case(State.Active):
			UpdateActive();
			break;
		case(State.Cooldown):
			UpdateCooldown();
			break;
		}
	}
	
	protected void StartTell() {
		timer = 0;
		_state = State.Tell;
	}
	
	protected void StartActive() {
		timer = 0;
		_state = State.Active;
	}
	
	protected void StartCooldown() {
		timer = 0;
		_state = State.Cooldown;
	}
	
	protected void UpdateTell() {
		
		// Affect velocity
		owner.actionVelocity = tellVelocity;
		
		// Check whether to move to next state
		timer += Time.deltaTime;
		if(timer > tellTime) {
			StartActive();
		}
	}
	
	protected void UpdateActive() {
		
		// Affect velocity
		owner.actionVelocity = activeVelocity;
		
		// Check whether to move to next state
		timer += Time.deltaTime;
		if(timer > tellTime) {
			StartCooldown();
		}
	}
	
	protected void UpdateCooldown() {
		
		// Affect velocity
		owner.actionVelocity = cooldownVelocity;
		
		// Check whether to move to next state
		timer += Time.deltaTime;
		if(timer > tellTime) {
			FinishMove();
		}
	}
	
	protected void FinishMove() {
		// TODO: Tell owner that you're no longer doing this move
		
	}
}
