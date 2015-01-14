using UnityEngine;
using System.Collections;

public class PostureKeeper : MonoBehaviour {

	public float velocity = 5;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		HingeJoint2D j = gameObject.GetComponent<HingeJoint2D> ();
		float deltaAngle = j.jointAngle;
		JointMotor2D motor = j.motor;
		motor.motorSpeed = -deltaAngle * velocity;
		gameObject.GetComponent<HingeJoint2D> ().motor = motor;
	}

}
