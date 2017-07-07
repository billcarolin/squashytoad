using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour {

	public float jumpElevationInDegrees = 45;
	public float jumpSpeedInMPS = 5;
	public float jumpGroundClearance = 2;
	public float jumpSpeedTolerance = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool isOnGround = Physics.Raycast (transform.position, -transform.up, jumpGroundClearance);
		Debug.DrawRay (transform.position, -transform.up * jumpGroundClearance, Color.blue);
		var speed = GetComponent<Rigidbody> ().velocity.magnitude;
		bool isNearStationary = speed < jumpSpeedTolerance;
		
		if(Input.GetKeyDown(KeyCode.Space) && isOnGround && isNearStationary){			
			//1. Get the camera forward vector (look direction)
			var camera = GetComponentInChildren<Camera> ();
			//Debug.DrawRay (transform.position, camera.transform.forward,Color.blue);
			//2. Project on Y axis (horizontal plane) in order to ignore Y position and only use x rotation
			var projectedLookDirection = Vector3.ProjectOnPlane (camera.transform.forward, Vector3.up);
			//Debug.DrawRay (transform.position, projectedLookDirection,Color.blue);
			//3. Rotate up by degrees in jump elevation 
			var radiansToRotate = Mathf.Deg2Rad * jumpElevationInDegrees;
			var unnormalizedJumpDirection = Vector3.RotateTowards (projectedLookDirection, Vector3.up, radiansToRotate, 0);
			//4. normalize the result vector to 1 and multiply by the configured jump speed.
			var jumpVector = unnormalizedJumpDirection.normalized * jumpSpeedInMPS;
			//Debug.DrawRay (transform.position, jumpVector,Color.green);
			GetComponent<Rigidbody> ().AddForce (jumpVector, ForceMode.VelocityChange);
		}
	}
}
