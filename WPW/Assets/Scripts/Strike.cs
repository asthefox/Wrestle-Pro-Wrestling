using UnityEngine;
using System.Collections;

public class Strike : ActionMove {

	public void Start () {
		base.Start();
		
		tellTime = 200;
		activeTime = 100;
		cooldownTime = 200;
		
		tellVelocity = -0.6f;
		activeVelocity = 0.6f;
		cooldownVelocity = 0.2f;
		
		Debug.Log ("Strike Starting");
	}
}
