﻿using UnityEngine;
using System.Collections;

public class SpawnerPipe : MonoBehaviour {

	[SerializeField]
	private GameObject pipeHolder;
	// Use this for initialization
	void Start () {
		StartCoroutine (_Spawner ());
	}

	IEnumerator _Spawner() {
		yield return new WaitForSeconds (1);
		Vector3 temp = pipeHolder.transform.position;
		temp.y = Random.Range (1.5f, 4.5f);
		Instantiate (pipeHolder, temp, Quaternion.identity);
		StartCoroutine (_Spawner ());
	}
	// Update is called once per frame
	void Update () {
	
	}
}
