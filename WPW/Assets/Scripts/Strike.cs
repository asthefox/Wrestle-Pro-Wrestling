using UnityEngine;
using System.Collections;

public class Strike : ActionMove {

	public void Start () {
		base.Start();
		
		tellTime = 200;
		activeTime = 100;
		cooldownTime = 200;
		
		tellVelocity = -0.6;
		activeVelocity = 0.6;
		cooldownVelocity = 0.2;
		
		Debug.Log ("Strike Starting");
	}
}
