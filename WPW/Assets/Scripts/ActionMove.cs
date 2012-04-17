using UnityEngine;
using System.Collections;

public class ActionMove : MonoBehaviour {
	
	public enum State {
		Tell = 0,
		Active = 1,
		Cooldown = 2
	}
	
	public Wrestler owner;
	
	public State state = State.Tell;
	public float timer = 0;
	
	public float range = 5;
	
	// All times in milliseconds
	public float tellTime = 0.200f;
	public float activeTime = 0.200f;
	public float cooldownTime = 0.200f;
	
	public float tellVelocity = 0;
	public float activeVelocity = 0;
	public float cooldownVelocity = 0;	
	

	public void Start () {
		owner = GetComponent<Wrestler>();
		timer = 0;
		state = State.Tell;
		
		tellTime = 0.200f;
		activeTime = 0.200f;
		cooldownTime = 0.200f;
	
		tellVelocity = 0;
		activeVelocity = 0;
		cooldownVelocity = 0;	
	}
	
	public void StartMove () {
		owner.currentAction = this;
		StartTell();
	}
	
	public void UpdateMove () {
		switch(state){
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
		state = State.Tell;
	}
	
	protected void StartActive() {
		timer = 0;
		state = State.Active;
	}
	
	protected void StartCooldown() {
		timer = 0;
		state = State.Cooldown;
	}
	
	protected virtual void UpdateTell() {
		
		Debug.Log("Updating Tell...");
		
		// Affect velocity
		owner.actionVelocity = tellVelocity;
		
		// Check whether to move to next state
		timer += Time.deltaTime;
		if(timer > tellTime) {
			Debug.Log("Switching to Active...");
			StartActive();
		}
	}
	
	protected virtual void UpdateActive() {
		
		Debug.Log("Updating Active...");
		
		// Affect velocity
		owner.actionVelocity = activeVelocity;
		
		// Check whether to move to next state
		timer += Time.deltaTime;
		if(timer > tellTime) {
			StartCooldown();
		}
	}
	
	protected virtual void UpdateCooldown() {
		
		Debug.Log("Updating Cooldown...");
		
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
		owner.state = Wrestler.State.Idle;
		owner.actionVelocity = 0;
		owner.face.renderer.material = owner.defaultMat;
	}
	
	protected bool CheckRange() {
		return (owner.distanceToOpponent < range);
	}
	
	public virtual void LandMove() {
		owner.currentConflict.SetResolution(this);
	}
		
	public virtual void UpdateHitting() {
		
	}
	
	public virtual void EndHitting() {
		owner.currentConflict.state = Conflict.State.Reset;
	}
}
