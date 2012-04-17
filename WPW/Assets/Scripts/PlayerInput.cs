using UnityEngine;
using System.Collections;

public class PlayerInput : WrestlerInput
{
	protected bool grapplePressed = false;
	protected bool strikePressed = false;
	protected bool counterPressed = false;
	
	void Start(){
		base.Start();
		
		
	}
	
	public override void HandleApproachInput () {
		if(grapplePressed){
			owner.StartGrapple();
		}
		if(strikePressed){
			owner.StartStrike();
		}
		if(counterPressed){
			owner.StartCounter();
		}
	}
	
	public void OnGUI() {
		if(owner.currentConflict != null && owner.currentConflict.state == Conflict.State.Approach)
		{
			ApproachGUI();
		}
	}
	
	protected void ApproachGUI() {
		grapplePressed = false;
		strikePressed = false;
		counterPressed = false;
		
		if(owner.state == Wrestler.State.Idle){
			if (GUI.Button(new Rect (10,10,100,60), "Grapple")){
				grapplePressed = true;
			}
			if (GUI.Button (new Rect (10,70,100,60), "Strike")){
				strikePressed = true;
			}
			if (GUI.Button (new Rect (10,130,100,60), "Counter")){
				counterPressed = true;
			}
		}		
	}
}

