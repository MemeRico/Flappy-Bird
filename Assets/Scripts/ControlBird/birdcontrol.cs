﻿using UnityEngine;
using System.Collections;

public class birdcontrol : MonoBehaviour {

	public static birdcontrol instance;

	public float bounceForce;
	private Rigidbody2D myBody;
	private Animator anim;

	[SerializeField]
	private AudioSource audioSource;

	[SerializeField]
	private AudioClip flyClip,pingClip,deadClip;

	private bool isAlive;
	private bool didFlap;

	private GameObject spawner;
	public float flag = 0;
	public int score = 0;

	void Awake(){
		isAlive = true;
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		_MakeInstance ();
		spawner = GameObject.Find ("Spawner Pipe");
	}

	void _MakeInstance(){
		if (instance == null) {
			instance = this;
		}
	}
	// Use this for initialization


	void _BirdMoveMent(){
		if (isAlive) {
			if (didFlap) {
				didFlap = false;
				myBody.velocity = new Vector2 (myBody.velocity.x, bounceForce);
				audioSource.PlayOneShot (flyClip);
			}
		}
		if (Input.GetMouseButtonDown (0)) {
			
		}
		if (myBody.velocity.y > 0) {
			float angel = 0;
			angel = Mathf.Lerp (0, 90, myBody.velocity.y / 7);
			transform.rotation = Quaternion.Euler (0, 0, angel);
		} else if (myBody.velocity.y == 0) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
		} else {
			float angel = 0;
			angel = Mathf.Lerp (0, -90, -myBody.velocity.y / 7);
			transform.rotation = Quaternion.Euler (0, 0, angel);
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		_BirdMoveMent ();
	}

	void Start () {

	}
	public void FlapButton(){
		didFlap = true;
	}
	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "PiperHolder") {
			score++;
			if (gamePlayController.instance != null) {
				gamePlayController.instance._setScore(score);
			}
			audioSource.PlayOneShot (pingClip);
		}
	}
	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Pipe" || target.gameObject.tag == "Ground") {
			flag = 1;
			if (isAlive) {
				isAlive = false;
				Destroy (spawner);
				audioSource.PlayOneShot (deadClip);
				anim.SetTrigger("dead");
			}
			if (gamePlayController.instance != null) {
				gamePlayController.instance._birdDead ();
			}
		}
			
	}
}