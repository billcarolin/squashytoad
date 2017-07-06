using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour {

	public Vector3 jumpVector	;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var projectedJumpVector = Vector3.ProjectOnPlane (jumpVector, Vector3.up);
		Debug.DrawRay (transform.position, projectedJumpVector,Color.blue);
		var radiansToRotate = Mathf.Deg2Rad * 45;
		var rotatedJumpVector = Vector3.RotateTowards (projectedJumpVector, Vector3.up, radiansToRotate, 0);
		Debug.DrawRay (transform.position, rotatedJumpVector, Color.cyan);
		if(Input.GetKeyDown(KeyCode.Space)){
			GetComponent<Rigidbody> ().AddForce (jumpVector, ForceMode.VelocityChange);
		}
	}
}
