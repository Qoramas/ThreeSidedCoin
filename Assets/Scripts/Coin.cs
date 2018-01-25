using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Coin") {
			Physics.IgnoreCollision (collision.collider, this.GetComponent<Collider>());
		}
	}
}
