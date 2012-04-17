using UnityEngine;
using System.Collections;

public class Wrestler : MonoBehaviour {
	
	public enum State {
		Idle = 0,
		Strike = 1,
		Grapple = 2,
		Counter = 3,
		Stunned = 4
	}
	
	public float stamina = 1.0f;
	public float mana = 0.0f;
	
	
	public GameObject face;
	
	public Material strikeMat;
	public Material counterMat;
	public Material grappleMat;
	public Material defaultMat;
	public Material stunMat;
	
	public State state = State.Idle;
	
	public Grapple grappleMove;
	public Counter counterMove;
	public Strike strikeMove;
	public Stunned stunnedMove;
	
	public WrestlerInput inputDevice;
	public Conflict currentConflict;
	public ActionMove currentAction;
	public Wrestler opponent;
	public Vector3 directionToOpponent;
	public float distanceToOpponent;
	public float walkSpeed = 5;
	public float actionVelocity;
	
	public Transform leftShoulder;
	public Transform rightShoulder;
	public Transform leftHand;
	public Transform rightHand;
	public Transform leftGrip;
	public Transform rightGrip;
	
	
	void Start () {
		walkSpeed = .05f; //setting this again for now to compensate for prefabs not updating. Later remove this for custom inspector values
		actionVelocity = 0;
		face = transform.FindChild("Model/Pelvis/Waist/Neck/Head/Sunglasses").gameObject;
		distanceToOpponent = 100;
		stamina = 1.0f;
		mana = 0.0f;
	}
	
	void Update () {
		transform.rotation = Quaternion.Euler (new Vector3(0, transform.rotation.eulerAngles.y, 0));
		
		if (currentConflict != null) {
			directionToOpponent = Vector3.Normalize ( opponent.transform.position - this.transform.position );
			directionToOpponent = new Vector3( directionToOpponent.x, 0, directionToOpponent.z );
			distanceToOpponent = Vector3.Distance(opponent.transform.position, this.transform.position);
			switch (currentConflict.state) {
			case Conflict.State.Approach:
				if(state == State.Idle) {
					inputDevice.HandleApproachInput();
				}
				else {
					currentAction.UpdateMove();
				}
				if(currentConflict.approachingDone)
				{
					transform.Translate ( directionToOpponent * (walkSpeed * actionVelocity) , Space.World);
				}
				else
				{
					transform.Translate ( directionToOpponent * (walkSpeed * (1 + actionVelocity)) , Space.World);
					transform.LookAt ( opponent.transform.position );
				}
				break;
			case Conflict.State.Resolution:
				if(state == State.Grapple && !animation.isPlaying && !grappleMove.thrown) {
					inputDevice.HandleGrappleInput();
				}
				break;
			case Conflict.State.Reset:
				
				break;
			}
		}
		
		Animate();
	}
	
	public void StartGrapple(){
		state = State.Grapple;
		grappleMove.StartMove();
		face.renderer.material = grappleMat;
	}
	
	public void StartStrike(){
		state = State.Strike;
		strikeMove.StartMove();
		face.renderer.material = strikeMat;
	}
	
	public void StartCounter(){
		state = State.Counter;
		counterMove.StartMove();
		face.renderer.material = counterMat;
	}
	
	public void StartStun(float _stunTime){
		stunnedMove.activeTime = _stunTime;
		state = State.Stunned;
		stunnedMove.StartMove();
		face.renderer.material = stunMat;
	}
	
	public void GrappleLatch(){
		Debug.Log ("stop anim");
		animation.Stop();
	}
	
	void Animate(){
		if (state == State.Strike) {
			if (strikeMove.state == ActionMove.State.Tell)
				animation.Play("StrikeTell");
			else if (strikeMove.state == ActionMove.State.Active)
				animation.Play ("Strike");
			else animation.CrossFade ("Idle");
		}
		else if (state == State.Grapple){
			if (grappleMove.state == ActionMove.State.Tell)
				animation.Play("GrappleTell");
			else if (grappleMove.state == ActionMove.State.Active) {
				if (currentConflict.state == Conflict.State.Approach)
					animation.Play ("Grapple");
			}
			//else animation.CrossFade ("Idle");
		}
		else animation.CrossFade ("Idle");
	}
	
	public void ChangeMana(float val) {
		mana += val;
		Mathf.Clamp01(mana);
	}
	
	public void ChangeStamina(float val) {
		stamina += val;
		Mathf.Clamp01(stamina);
	}
	
	
	public int CalculateKickout()
	{
		float kickoutOdds = 0.05f + (1.5f * stamina);  
		float randomVal = Random.value;
		float difference = kickoutOdds - randomVal;
		
		if(difference > 60){
			return 1;
		}
		else if(difference > 30){
			return 2;
		}
		else if(difference >= 0){
			return 3;
		}
		else{
			return -1;
		}
	}
}
