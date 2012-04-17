using UnityEngine;
using System.Collections;

public class WrestlerInput : MonoBehaviour
{
	Wrestler owner;
	public KeyCode grappleButton;
	public KeyCode strikeButton;
	public KeyCode counterButton;
	
	void Start(){
		owner = GetComponent<Wrestler>();
		owner.input = this;
	}
	
	public void HandleApproachInput () {
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

