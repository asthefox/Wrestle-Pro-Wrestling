using UnityEngine;
using System.Collections;

public class Strike : ActionMove {
	
	public float strikeForce = 500f;
	
	public void Start () {
		base.Start();
		
		owner.strikeMove = this;
		
		range = 2.5f;
		damage = 0.02f;
		manaChargeOnLanding = 0.02f;
		strikeForce = 500f;

		tellTime = 0.200f;
		activeTime = 0.100f;
		cooldownTime = 0.200f;
		
		tellVelocity = -0.6f;
		activeVelocity = 1.4f;
		cooldownVelocity = 0.2f;
	}
	
	protected override void UpdateActive() {
		
		//Debug.Log("Checking range");
		
		if(CheckRange()) {
			
			StartCooldown();
			
			// Is opponent currently countering (i.e. did this attack get countered)?
			//Debug.Log("In range for strike!");
			if(owner.opponent.state == Wrestler.State.Counter && 
				owner.opponent.currentAction.state == ActionMove.State.Active) {
				owner.opponent.currentAction.LandMove();
			}
			else {
				LandMove();
			}
		}
		
		base.UpdateActive();
	}
	
	public override void LandMove()
	{
		base.LandMove();
		owner.opponent.StartStun(0.2f);
		timer = 0;
		owner.opponent.rigidbody.AddForce((owner.directionToOpponent + new Vector3(0f,0f,0f)) * strikeForce);		
		GameObject.Find("Box").rigidbody.AddForce((owner.directionToOpponent + new Vector3(0f,0f,0f)) * strikeForce);		
	}
	
	public override void UpdateHitting() {
		if(state == ActionMove.State.Cooldown)
			UpdateCooldown();
		
		else {
			timer += Time.deltaTime;
			
			if(timer > 1f)// && owner.opponent.rigidbody.velocity.magnitude < 1)
				EndHitting();
		}
	}

}
