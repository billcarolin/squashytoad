using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		Destroy(other.GetComponentInParent<Rigidbody>().gameObject);
    }
}
