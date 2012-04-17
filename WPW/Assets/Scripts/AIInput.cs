using UnityEngine;
using System.Collections;

public class DebugInput : WrestlerInput
{
	public KeyCode grappleButton;
	public KeyCode strikeButton;
	public KeyCode counterButton;
	
	void Start(){
		base.Start();
		
		grappleButton = KeyCode.UpArrow;
		counterButton = KeyCode.DownArrow;
		strikeButton = KeyCode.LeftArrow;
	}
	
	public override void HandleApproachInput () {
		if(Input.GetKeyDown(grappleButton)){
			owner.StartGrapple();
		}
		if(Input.GetKeyDown(strikeButton)){
			owner.StartStrike();
		}
		if(Input.GetKeyDown(counterButton)){
			owner.StartCounter();
		}
	}
}

