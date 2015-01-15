using UnityEngine;
using System.Collections;

public class SchnauzerArm : MonoBehaviour {

	public float speed = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		HingeJoint2D j = gameObject.GetComponent<HingeJoint2D> ();
		JointMotor2D m = j.motor;
		if (Input.GetAxis ("moveArm") > 0)
			m.motorSpeed = speed;
		else if (Input.GetAxis ("moveArm") < 0)
			m.motorSpeed = -speed;
		else
			m.motorSpeed = 0;

		j.motor = m;
	}
}
