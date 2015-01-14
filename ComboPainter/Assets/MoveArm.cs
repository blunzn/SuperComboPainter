using UnityEngine;
using System.Collections;

public class MoveArm : MonoBehaviour {
	public float speed = 500;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		JointMotor2D motor = gameObject.GetComponent<SliderJoint2D> ().motor;
		if (Input.GetKey (KeyCode.UpArrow)) {
						motor.motorSpeed = -speed;
				} else if (Input.GetKey (KeyCode.DownArrow)) {
			
						motor.motorSpeed = speed;
				} else {
						motor.motorSpeed = 0;
				}

		gameObject.GetComponent<SliderJoint2D> ().motor = motor;
	}
}
