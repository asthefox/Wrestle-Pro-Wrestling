using UnityEngine;
using System.Collections;

public class Grapple : ActionMove {
	
	public float armRotationAngle;
	public float previousArmRotationTimer;
	protected float previousArmRotationAngle;
	protected Vector3 throwDir;
	public float throwForce;
	public bool thrown = false;
	
	void Start () {
		base.Start();
		
		owner.grappleMove = this;
		
		range = 4.8f;

		tellTime = 0.300f;
		activeTime = 0.150f;
		cooldownTime = 0.200f;
		
		tellVelocity = -0.9f;
		activeVelocity = 0.6f;
		cooldownVelocity = 0.1f;
		
		armRotationAngle = 0;
		previousArmRotationAngle = 0;
		throwForce = 500;
	}
	
	protected override void UpdateActive() {
		
		if(CheckRange()) {
			//Debug.Log("In range for grapple!");
			LandMove();
		}
		
		base.UpdateActive();
	}
	
	public override void LandMove()
	{
		base.LandMove();
		thrown = false;
		owner.rigidbody.isKinematic = true;
		owner.opponent.rigidbody.isKinematic = true;
		owner.collider.enabled = false;
		
		timer = 0;
	}
	
	public override void UpdateHitting() {
		if(state == ActionMove.State.Cooldown)
			UpdateCooldown();
		
		else {
			if(!owner.animation.isPlaying && !thrown){
				owner.rightShoulder.localRotation = Quaternion.Euler ( new Vector3(armRotationAngle,0,0));
				owner.leftShoulder.localRotation = Quaternion.Euler ( new Vector3(armRotationAngle,0,0));
				owner.opponent.transform.position = owner.leftHand.position + owner.transform.right * 0.6f;
			}
			
			if (thrown) {
				timer += Time.deltaTime;
			
				if(timer > 6f || 
					(owner.opponent.rigidbody.velocity.magnitude < 1 && owner.opponent.transform.position.y <= 0.5f)) {
					EndGrapple();
				}
			}
			
			
		}
	}
	
	public void Throw () {
		
		if (armRotationAngle == previousArmRotationAngle) {
			Debug.Log ("angles are the same!");
		}
		else if (armRotationAngle > previousArmRotationAngle) {
			Debug.Log("throw down");
			throwDir = -owner.rightShoulder.up;
		}
		else {
			Debug.Log ("throw up");
			throwDir = owner.rightShoulder.up;
		}
		
//		Vector3 newDir = Vector3.Normalize (throwDir);
//		if (newDir.x < 0 && newDir.y < 0) {
//			newDir = -Vector3.up;
//		}
//		
//		Debug.Log ("Throw Dir: " + throwDir);
		
		owner.opponent.rigidbody.isKinematic = false;
		owner.opponent.rigidbody.AddForce( throwDir * throwForce );
		thrown = true;
		StartCooldown();
	}
	
	public void EndGrapple() {
//		StartCooldown();
		EndHitting();
		owner.rigidbody.isKinematic = false;
		owner.collider.enabled = true;
	}
	
	public void SetRotationAngle( float _armRotationAngle ) {
		previousArmRotationAngle = armRotationAngle;
		armRotationAngle = _armRotationAngle;
		
	
//		previousArmRotationTimer += Time.deltaTime;
//		if (previousArmRotationTimer > 0.05) {
//			previousArmRotationTimer = 0;
//			previousArmRotationAngle = armRotationAngle;
//		}
			
	}
}
