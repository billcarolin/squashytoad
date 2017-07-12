using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

	public GameObject UICanvas;

	public void OnDeath()
	{
		UICanvas.SetActive(true);
	}
}
