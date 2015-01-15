using UnityEngine;
using System.Collections;

public class Walk : MonoBehaviour {

	public float maxSpeed = 5;
	public float acceleration = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		float walkDirection = Input.GetAxis("walk");

		if (walkDirection > 0 && rigidbody2D.velocity.x < maxSpeed) {
						rigidbody2D.AddForce (Vector2.right * acceleration);
				} else if (walkDirection < 0 && rigidbody2D.velocity.x > -maxSpeed) {
			rigidbody2D.AddForce (Vector2.right * -acceleration);


				}
	}
}
