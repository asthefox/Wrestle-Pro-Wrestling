using UnityEngine;
using System.Collections;

public class Counter : ActionMove {

	void Start () {
		base.Start();
		owner.counterMove = this;
	}
	
	void Update () {
		
	}
}
