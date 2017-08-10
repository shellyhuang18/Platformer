﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	public float enemySpeed;
	public int XMoveDirection;
	public bool foundTarget;

	void Awake(){
		foundTarget = false;
	}
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (XMoveDirection, 0));
		if (!foundTarget) Move (enemySpeed);
		else Move (0);

		if (hit) {
			if (hit.collider.tag == "Player") {
				if (hit.distance < 5f)
					foundTarget = true;
				else
					foundTarget = false;
			} else if (hit.collider.tag == "ground") {
				foundTarget = false;
				if (hit.distance < 1.5f)
					Flip (); 
			} else {
				foundTarget = false;
			}
		} else {
			foundTarget = false;
		}
	}	

	void Move(float speed){
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (XMoveDirection * speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}
	void Flip(){
		Vector2 scale = gameObject.transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
		if (XMoveDirection > 0) {
			XMoveDirection = -1;
		} else {
			XMoveDirection = 1;
		}
	}
}
