using UnityEngine;
using System.Collections;

public class WrestlerInput : MonoBehaviour
{
	protected Wrestler owner;
	
	public void Start(){
		owner = GetComponent<Wrestler>();
		owner.input = this;
	}
	
	public virtual void HandleApproachInput () {}
}

