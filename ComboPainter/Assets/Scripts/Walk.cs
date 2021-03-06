﻿using UnityEngine;
using System.Collections;

public class Walk : MonoBehaviour {

	public float maxSpeed = 5;
	public float acceleration = 1;

	private SpriteRenderer idle;
	private SpriteRenderer walk;

	public bool flipRoot = false;

	private bool hasAnimations;

	// Use this for initialization
	void Start () {

		hasAnimations = transform.FindChild ("walk") != null;

		if (hasAnimations) 
		{
			walk = transform.FindChild ("walk").gameObject.GetComponent<SpriteRenderer> ();
			idle = transform.FindChild ("idle").gameObject.GetComponent<SpriteRenderer> ();
			
			if (walk != null) {
				walk.enabled = true;
				idle.enabled = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		float walkDirection = Input.GetAxis("walk");
		
		Vector3 scale = Vector3.one;
		
		CharacterManager manager = GameObject.Find("GameController").GetComponent<CharacterManager> ();

		if (walkDirection > 0) {
			scale.x = 1;
			if(rigidbody2D.velocity.x < maxSpeed/(float)(manager.finehide+1))
				rigidbody2D.AddForce (Vector2.right * acceleration);

		} else if (walkDirection < 0) 
		{
			scale.x = -1;
			if(rigidbody2D.velocity.x > -maxSpeed/(float)(manager.finehide+1))
				rigidbody2D.AddForce (Vector2.right * -acceleration);
		}



		if (hasAnimations) {
			if (rigidbody2D.velocity.magnitude > 0.5) {
				walk.enabled = true;
				idle.enabled = false;
			} else if (walk.enabled) {
				walk.enabled = false;
				idle.enabled = true;
			}
			
			if(!flipRoot)
			{
				walk.transform.localScale = scale;
				idle.transform.localScale = scale;

			}
		}
		if (flipRoot)
			transform.localScale = scale;
	}
}
