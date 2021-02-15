using UnityEngine;
using System.Collections;

public class pipecontrol : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (birdcontrol.instance.flag != null) {
			if (birdcontrol.instance.flag == 1) {
				Destroy (GetComponent<pipecontrol> ());
			}
		}
		_PipeMovement ();
	}

	void _PipeMovement(){
		Vector3 temp = transform.position;
		temp.x -= speed * Time.deltaTime;
		transform.position = temp;

	}
	void OnCollisionEnter2D(Collision2D target) {
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "Destroy") {
			Destroy (gameObject);
		}
	}
}
