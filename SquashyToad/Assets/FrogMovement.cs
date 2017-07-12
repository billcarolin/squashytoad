using UnityEngine;
using System.Collections;

public class FrogMovement : MonoBehaviour {

	public float jumpElevationInDegrees = 45;
	public float[] jumpSpeedInCMPS = { 2, 4, 7 };
	public float jumpGroundClearance = 2;
	public float jumpSpeedTolerance = 5;

	public int collisionCount = 0;
	public int hopCount = 0;

	// Use this for initialization
	void Start () {

	}

	void OnCollisionEnter()
	{
		collisionCount++;
	}

	void OnCollisionExit()
	{
		collisionCount--;
	}

	// Update is called once per frame
	void Update () {
		bool isOnGround = collisionCount > 0;

		if (isOnGround)
		{
			hopCount = 0;
		}

		if (Input.GetKeyDown(KeyCode.Space) && hopCount < jumpSpeedInCMPS.Length)
		{
			var camera = GetComponentInChildren<Camera>();
			var projectedLookDirection = Vector3.ProjectOnPlane(camera.transform.forward, Vector3.up);
			var radiansToRotate = Mathf.Deg2Rad * jumpElevationInDegrees;
			var unnormalizedJumpDirection = Vector3.RotateTowards(projectedLookDirection, Vector3.up, radiansToRotate, 0);
			var jumpVector = unnormalizedJumpDirection.normalized * jumpSpeedInCMPS[hopCount];
			GetComponent<Rigidbody>().AddForce(jumpVector, ForceMode.VelocityChange);
			hopCount++;
		}
	}

	//	
	// Old Update using Raycast example 
//	void Update () {
//		bool isOnGround = Physics.Raycast (transform.position, -transform.up, jumpGroundClearance);
//		Debug.DrawRay (transform.position, -transform.up * jumpGroundClearance, Color.blue);
//		var speed = GetComponent<Rigidbody> ().velocity.magnitude;
//		bool isNearStationary = speed < jumpSpeedTolerance;
//
//		if(Input.GetKeyDown(KeyCode.Space) && isOnGround && isNearStationary){			
//			//1. Get the camera forward vector (look direction)
//			var camera = GetComponentInChildren<Camera> ();
//			//Debug.DrawRay (transform.position, camera.transform.forward,Color.blue);
//			//2. Project on Y axis (horizontal plane) in order to ignore Y position and only use x rotation
//			var projectedLookDirection = Vector3.ProjectOnPlane (camera.transform.forward, Vector3.up);
//			//Debug.DrawRay (transform.position, projectedLookDirection,Color.blue);
//			//3. Rotate up by degrees in jump elevation 
//			var radiansToRotate = Mathf.Deg2Rad * jumpElevationInDegrees;
//			var unnormalizedJumpDirection = Vector3.RotateTowards (projectedLookDirection, Vector3.up, radiansToRotate, 0);
//			//4. normalize the result vector to 1 and multiply by the configured jump speed.
//			var jumpVector = unnormalizedJumpDirection.normalized * jumpSpeedInMPS;
//			//Debug.DrawRay (transform.position, jumpVector,Color.green);
//			GetComponent<Rigidbody> ().AddForce (jumpVector, ForceMode.VelocityChange);
//		}
//	}

}
