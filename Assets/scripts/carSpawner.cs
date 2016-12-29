using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpawner : MonoBehaviour {

	public GameObject[] cars;
	public float maxPos = 2.54f;
	public float delayTimer = 1.5f;
	float timer;
	int carNo;

	// Use this for initialization
	void Start () {
		timer = delayTimer;
	}

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Vector3 carPos = new Vector3(Random.Range(-2.54f,2.54f),transform.position.y,transform.position.z);
			carNo = Random.Range (0,5);
			Instantiate (cars[carNo], carPos, transform.rotation);
			timer = delayTimer;
		}

	}



}
