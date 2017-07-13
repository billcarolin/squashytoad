using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void Start()
	{
		//used to hide the cursor in the Game View window.
//		Cursor.lockState = CursorLockMode.Locked;
//		Cursor.visible = false;
	}

	public void LoadNextScene(){
		int currentIndex = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (currentIndex + 1);
	}

	public void ReloadScene()
	{
		int currentIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentIndex);
	}

	public void Quit(){
		Debug.Log ("Application will Quit");
		Application.Quit ();
	}
}
