using UnityEngine;
using System.Collections;

public class Counter : ActionMove {

	void Start () {
		base.Start();
		owner.counterMove = this;
		tellTime = 0.05f;
		activeTime = 0.7f;
		cooldownTime = 0.1f;
	}
	
	public override void LandMove()
	{
		base.LandMove();
		owner.opponent.StartStun(1.2f);
		owner.currentConflict.state = Conflict.State.Approach;
	}
	
	void Update () {
		
	}
}
