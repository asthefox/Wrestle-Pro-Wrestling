using UnityEngine;
using System.Collections;

public class Stunned : ActionMove {

	void Start () {
		base.Start();
		owner.stunnedMove = this;
		
		tellTime = 0.0f;
		activeTime = 1.0f;
		cooldownTime = 0.0f;
	}
}
