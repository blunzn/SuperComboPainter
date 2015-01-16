using UnityEngine;
using System.Collections;

public class fly : MonoBehaviour {
	private CharacterManager manager;
	public float acceleration = 50;
	public float maxSpeed = 3;

	private SliderJoint2D joint;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find ("GameController").GetComponent<CharacterManager> ();

	}
	
	// Update is called once per frame
	void Update () {

		float direction = Input.GetAxis("moveArm");

		if (direction > 0) {
//			rotation.z -= speed;
			if(rigidbody2D.velocity.x < maxSpeed/(float)(manager.finehide+1))
				rigidbody2D.AddForce (Vector2.up * acceleration);
			
		} else if (direction < 0) 
		{
			//			rotation.z -= speed;
			if(rigidbody2D.velocity.x < maxSpeed/(float)(manager.finehide+1))
				rigidbody2D.AddForce (Vector2.up * -acceleration);
		}
	}
}
