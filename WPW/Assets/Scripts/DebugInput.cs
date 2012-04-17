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
	
	public override void HandleGrappleInput () {
//		base.HandleGrappleInput ();
		bool shouldThrow = true;
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			owner.grappleMove.SetRotationAngle ( 1 );
			owner.grappleMove.SetRotationAngle ( 0 );
		}
		else if (Input.GetKeyDown (KeyCode.DownArrow)){
			owner.grappleMove.SetRotationAngle ( -1 );
			owner.grappleMove.SetRotationAngle ( 0 );
		}
		else if (Input.GetKeyDown (KeyCode.LeftArrow)){
			owner.grappleMove.SetRotationAngle ( -101 );
			owner.grappleMove.SetRotationAngle ( -100 );
		}
		else if (Input.GetKeyDown (KeyCode.RightArrow)){
			owner.grappleMove.SetRotationAngle ( -124 );
			owner.grappleMove.SetRotationAngle ( -125 );
		}
		else {
			shouldThrow = false;
		}
		
		if(shouldThrow) {
			//owner.face.renderer.material = owner.strikeMat;
			owner.grappleMove.Throw();
		}
	}
}


