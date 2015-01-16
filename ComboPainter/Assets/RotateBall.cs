using UnityEngine;
using System.Collections;

public class RotateBall : MonoBehaviour {

	public float speed = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float walkDirection = Input.GetAxis("walk");
		
		Vector3 rotation = transform.rotation.eulerAngles;
		
		CharacterManager manager = GameObject.Find("GameController").GetComponent<CharacterManager> ();
		
		if (walkDirection > 0) {
			rotation.z -= speed;
//			if(rigidbody2D.velocity.x < maxSpeed/(float)(manager.finehide+1))
//				rigidbody2D.AddForce (Vector2.right * acceleration);
			
		} else if (walkDirection < 0) 
		{
			rotation.z -= speed;
			//			if(rigidbody2D.velocity.x > -maxSpeed/(float)(manager.finehide+1))
//				rigidbody2D.AddForce (Vector2.right * -acceleration);
		}

		Quaternion rotQuat = Quaternion.Euler (rotation);

		transform.rotation = rotQuat;

	}
}
