using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSpawner : MonoBehaviour {

	public GameObject[] lanePrefabs;
	public int maxLanes = 50;
	private float laneWidth = 10;

	// Use this for initialization
	void Start () {
		int lanesCreated = 0;
		while (lanesCreated < maxLanes) {
			float offset = lanesCreated * laneWidth;
			CreateRandomLane (offset);
			lanesCreated++;
		}			
	}

	void CreateRandomLane(float offset){
		int laneIndex = Random.Range (0, lanePrefabs.Length);
		var lane = Instantiate (lanePrefabs [laneIndex]);
		lane.transform.parent = transform;
		lane.transform.Translate (0, 0, offset);
	}

	// Update is called once per frame
	void Update () {

	}
}
