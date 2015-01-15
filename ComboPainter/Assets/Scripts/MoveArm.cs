using UnityEngine;
using System.Collections;

public class MoveArm : MonoBehaviour {
	public float speed = 500;
	public string up = "up";
	public string down = "down";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		SliderJoint2D slider = gameObject.GetComponent<SliderJoint2D>();
		JointMotor2D motor = slider.motor;
		if (Input.GetKey(up))
			motor.motorSpeed = -speed;
		else if (Input.GetKey(down))
			motor.motorSpeed = speed;
		else
			motor.motorSpeed = 0;
			//slider.useMotor = true;
//				} else if (Input.GetKey (KeyCode.DownArrow)) {
//			
//						motor.motorSpeed = speed;
//				} else {
//			slider.useMotor = false;
//				}

		slider.motor = motor;
	}
}
