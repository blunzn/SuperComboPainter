using UnityEngine;
using System.Collections;

public class MoveArm : MonoBehaviour {
	public float speed = 500;
	public string key = "a";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		JointMotor2D motor = gameObject.GetComponent<SliderJoint2D> ().motor;
		SliderJoint2D slider = gameObject.GetComponent<SliderJoint2D> ();
		if (Input.GetKey (key)) {
			slider.useMotor = true;
//				} else if (Input.GetKey (KeyCode.DownArrow)) {
//			
//						motor.motorSpeed = speed;
				} else {
			slider.useMotor = false;
				}

//		gameObject.GetComponent<SliderJoint2D> ().motor = motor;
	}
}
