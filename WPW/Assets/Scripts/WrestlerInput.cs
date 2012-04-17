using UnityEngine;
using System.Collections;

public class WrestlerInput : MonoBehaviour
{
	protected Wrestler owner;
	protected Vector3 throwClickDownPos;
	
	public void Start(){
		owner = GetComponent<Wrestler>();
		owner.input = this;
	}
	
	public virtual void HandleApproachInput () {}
	
	public virtual void HandleGrappleInput () {}
}

