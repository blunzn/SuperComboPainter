using UnityEngine;
using System.Collections;

public class SchnauzerArm : MonoBehaviour {

	public float speed = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CharacterManager manager = GameObject.Find ("GameController").GetComponent<CharacterManager> ();
		HingeJoint2D j = gameObject.GetComponent<HingeJoint2D> ();
		JointMotor2D m = j.motor;

		if (Input.GetAxis("moveArm") > 0)
			m.motorSpeed = speed / (float)(manager.finehide+1);
		else if (Input.GetAxis("moveArm") < 0)
			m.motorSpeed = -speed / (float)(manager.finehide+1);
		else
			m.motorSpeed = 0;

		j.motor = m;
	}
}
