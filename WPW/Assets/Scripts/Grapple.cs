using UnityEngine;
using System.Collections;

public class Grapple : ActionMove {

	void Start () {
		base.Start();
		
		owner.grappleMove = this;
	}
	
	protected override void UpdateActive() {
		
		if(CheckRange()) {
			//Debug.Log("In range for grapple!");
			LandMove();
		}
		
		base.UpdateActive();
	}
}
