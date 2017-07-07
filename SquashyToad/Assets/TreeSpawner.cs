using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour {

	public GameObject treePrefab;
	public int maximumTrees = 10;


	// Use this for initialization
	void Start () {
		int totalTrees = Random.Range (2, maximumTrees);
		createRandomTrees (totalTrees);
	}

	void createRandomTrees (int treeCount) {
		for (int x = 0; x < treeCount; x++) {
			CreateRandomTree ();
		}
	}

	void CreateRandomTree(){
		float treeX = Random.Range (-50, 50);
		float treeZ = Random.Range (-5, 5);
		var tree = Instantiate (treePrefab);
		tree.transform.parent = transform;
		tree.transform.localPosition = new Vector3(treeX, 0, treeZ);
		//tree.transform.localScale = new Vector3(0.25f,0.25f,0.25f);
	}

	// Update is called once per frame
	void Update () {

	}
}
