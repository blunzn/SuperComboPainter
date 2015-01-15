using UnityEngine;
using System.Collections;

public class RotateArm : MonoBehaviour {
	public float maxForce = 10;
	public int inputAxisFlip = 1;

	private float initialMotorSpeed;

	// Use this for initialization
	void Start () {
		initialMotorSpeed = gameObject.GetComponent<HingeJoint2D> ().motor.motorSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		HingeJoint2D j = gameObject.GetComponent<HingeJoint2D> ();
		JointMotor2D m = j.motor;
		
		CharacterManager manager = GameObject.Find ("GameController").GetComponent<CharacterManager> ();

		if (Input.GetAxis ("moveArm") * inputAxisFlip > 0) {
			m.motorSpeed = initialMotorSpeed/(float)(manager.finehide+1);
						m.maxMotorTorque = maxForce;
				} else {
						m.motorSpeed = 0;
//						m.maxMotorTorque = 0;
				}
		
		j.motor = m;
	}
}
